using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkControl : MonoBehaviour {

    private SocketConnect sc;
    // Use this for initialization
    void Start () {
        //if(sc == null)
        //{
        //    //获得连接实例
        //    sc = SocketConnect.getSocketInstance();
        //}
        
	}
	
	// Update is called once per frame
	void Update () {

        ////更新数据
        //sc.SendMSG(ByteUtil.int2ByteArray(NetworkData.SENDROTATION));
        //sc.SendMSG(ByteUtil.float2ByteArray(NetworkData.RotX));
        //sc.SendMSG(ByteUtil.float2ByteArray(NetworkData.RotY));
        //sc.SendMSG(ByteUtil.float2ByteArray(NetworkData.RotZ));

    }
}
