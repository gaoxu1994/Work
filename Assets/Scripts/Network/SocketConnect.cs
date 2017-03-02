using UnityEngine;
using System;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class SocketConnect
{
    private Socket mySocket;
    private static SocketConnect st;
    public static System.Object datalock = new System.Object();//锁
    Thread thread;
    bool getMSGFlag = false;
    //"192.168.1.152", 8711
    String ipStr = "192.168.1.156";
    int port = 8711;
    //单例模式
    public static SocketConnect getSocketInstance()//获取SocketText对象
    {
        if (st == null)
        {
            st = new SocketConnect();
        }
        return st;
    }
    SocketConnect()//构造器
    {
        mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress ip = IPAddress.Parse(ipStr);
        Debug.Log("Ip" + ipStr);
        IPEndPoint ipe = new IPEndPoint(ip, port);
        IAsyncResult result = mySocket.BeginConnect(ipe, new AsyncCallback(ConnectCallBack), mySocket);
        //mySocket.Connect(ipe);
        bool connectsucces = result.AsyncWaitHandle.WaitOne(5000, true);//超时
        if (connectsucces)//连接成功
        {
            //接收数据线程
            thread = new Thread(new ThreadStart(GetMSG));//线程方法
            //thread.IsBackground = true;
            getMSGFlag = true;
            thread.Start();
        }
        else
        {
            Debug.Log("time out");
        }
    }
    void ConnectCallBack(IAsyncResult ast)
    {
        Debug.Log("connect success...");
    }
    int readInt()
    {
        byte[] bint = readPackage(4);
        return ByteUtil.byteArray2Int(bint, 0);
    }
    float readFloat()
    {
        byte[] bfloat = readPackage(4);
        return ByteUtil.byteArray2Float(bfloat, 0);
    }
    byte[] readPackage(int len)
    {
        byte[] bPackage = new byte[len];        //收到的数据包
        int status = mySocket.Receive(bPackage);//第一次接受的长度
        while (status != len)              //循环接收 直到收够指定长度
        {
            int index = status;         //记录已经收到的长度
            byte[] tempData = new byte[len - status];
            int count = mySocket.Receive(tempData);     //接受剩下的
            status += count;            //更新已接受到的长度
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    bPackage[index + i] = tempData[i]; //合并数组
                }
            }
        }
        return bPackage;
    }
    private void GetMSG()       //接受数据包线程
    {
        while (getMSGFlag)
        {
            try
            {
                int sign = readInt();
                if (sign == NetworkData.RECEIVESUCCEED)      //收到成功信号
                {
                    lock (datalock)
                    {
                        NetworkData.isSucceed = true;
                    }
                }
            }
            catch (Exception e)
            {                              
                Debug.LogError(e.ToString());
            }
        }
    }

    public void SendInt(int msg)
    {
        SendMSG(ByteUtil.int2ByteArray(msg));
    }
    public void SendFloat(float msg)
    {
        SendMSG(ByteUtil.float2ByteArray(msg));
    }

    //发送数据方法
    private void SendMSG(byte[] bytes)
    {
        if (!mySocket.Connected)//断开连接
        {
            Debug.Log("bread connect (sendMSG)");                                       
        }
        try
        {
            //发送数组
            mySocket.Send(bytes, SocketFlags.None);

        }
        catch (Exception e)
        {
            Debug.Log("bread connect (sendMSG_catch)");
            Debug.Log(e.ToString());                               
        }
    }
    private bool isSocketConnect(Socket client)//判断客户端是否在线
    {
        bool blockingState = client.Blocking;
        try
        {
            byte[] tmp = new byte[1];
            client.Blocking = false;
            client.Send(tmp, 0, 0);
            return true;
        }
        catch (SocketException e)
        {
            if (e.NativeErrorCode.Equals(10035))
                return true;
            else
                return false;
        }
        finally {
            client.Blocking = blockingState;
        }
    }

    public void close()
    {
        getMSGFlag = false;
        mySocket.Close();
        st = null;
        //thread.Abort();
    }
}
