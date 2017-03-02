using UnityEngine;
using System.Collections;

//网络传输数据
public enum TrafficType
{
    No = -1,
    Car = 0,        //汽车类型
    AirPlane = 1    //飞机类型
}

//组装的类型
public enum SignType
{
    NO = -1,
    SedanOrFighter = 0,    //轿车或者战斗机
    SUVOrPropeller = 1,     //SUV或者螺旋桨飞机
    TruckOrAirliner = 2     //卡车或者客机
}

public enum ColorType
{
    Black = 1,
    Red = 2,
    Blue = 3,
    Yellow = 4
}
public static class NetworkData {

    #region NetWork Sign
    //发送旋转姿态信号
    public static int SENDROTATION = 0;
    //发送数据信号
    public static int SENDDATA = 1;
    //发送请求链接信号
    public static int SENDCONNECT = 2;
    //收到成功连接信号
    public static int RECEIVESUCCEED = 3;
    //收到连接失败信号
    public static int RECEIVEFAILD = 4;
    //发送断开连接信号
    public static int SENDDISCONNECT = 5;

    #endregion
    #region 相关标志位
    //连接数据是否成功
    public static bool isSucceed = false;
    //是否提交
    public static bool isSubmit = false;

    #endregion 


    #region Data
    //交通工具的类型///
    /// <summary>
    /// 汽车或者飞机
    /// </summary>
    public static TrafficType TypeTraffic = TrafficType.No;
    //选择组装类型的信号
    /// <summary>
    /// 0------轿车/战斗机
    /// 1------SUV/螺旋桨飞机
    /// 2------卡车/客机
    /// </summary>
    public static SignType TypeSign = SignType.NO;
    /// <summary>
    /// 组装的模型颜色以及材质
    /// </summary>
    public static ColorType TypeColor = ColorType.Black;


    #endregion

}
