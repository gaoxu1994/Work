using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//脚本挂在Modelshow GameObject下
public class ModelViewControl : MonoBehaviour {

    //是否提交
    public static bool isSubmit = false;

    //是否初始化数据标志位
    public static bool isInit = false;

    private bool isEnter = false;    //判断点击区域是否为视窗        
    private bool isClick = false ;     //是否点下事件
    private Vector3 startPos;       //点下开始位置
    private Vector3 endPos;         //点下终点位置
    private float Move_X;           //x方向上的移动距离
    private float Move_Y;           //Y方向上的移动距离
    private Vector3 up, right;

    //回调间距
    float interval = 0.1f;
    float clickBeginTime = 0.0f;
    //模型引用
    private Transform model;
    private GameObject RTCamera;
    private GameObject MainCom;


    private RenderTexture rt;

    private Object preb;

    void Start () {

        RTCamera = GameObject.Find("RTCamera");
        rt = RTCamera.GetComponent<Camera>().targetTexture;
        model = RTCamera.transform.Find("Models");
        //注册监听
        EventTriggerListener.Get(gameObject).onEnter = OnModelViewEnter;
        EventTriggerListener.Get(gameObject).onExit = OnModelViewExit;
        if (!isInit)
        {
            //初始化模型数据
            initModel();
        }
        
    }
    //初始化模型数据
    void initModel()
    {
        if (NetworkData.TypeTraffic == TrafficType.Car)
        {
            preb = Resources.Load("Cube", typeof(GameObject));
            MainCom = Instantiate(preb) as GameObject;
            MainCom.transform.parent = model;
            MainCom.name = "MainCom";
            MainCom.transform.localPosition = Vector3.zero;
        }
        else if (NetworkData.TypeTraffic == TrafficType.AirPlane)
        {
            preb = Resources.Load("Capsule", typeof(GameObject));
            MainCom = Instantiate(preb) as GameObject;
            MainCom.transform.parent = model;
            MainCom.name = "MainCom";
            MainCom.transform.localPosition = Vector3.zero;
        }

        isInit = true;

    }

    private void OnEnable()
    {
        isEnter = false;      
        isClick = false; 
    }

    private void OnDisable()
    {
        model.eulerAngles = Vector3.zero;
    }
    void OnModelViewEnter(GameObject go)
    {
        isEnter = true;
    }

    void OnModelViewExit(GameObject go)
    {
        isEnter = false;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
            startPos = Input.mousePosition;
            clickBeginTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }

        if (isClick && isEnter && (Time.time - clickBeginTime) > interval)
        {
            endPos = Input.mousePosition;
            Move_X = endPos.x - startPos.x;
            Move_Y = endPos.y - startPos.y;
           // Debug.Log("X:" + Move_X + "====== Y:" + Move_Y);
            Move_X = Mathf.Abs(Move_X) > 10 ? Move_X : 0;
            Move_Y = Mathf.Abs(Move_Y) > 10 ? Move_Y : 0;
            RotateModel(Move_X, Move_Y);
            clickBeginTime = Time.time;
        }
    }

    void RotateModel(float moveX,float moveY)
    {
        moveX /= 5.0f; Move_Y /= 10.0f;
        up = model.worldToLocalMatrix * model.up;
        right = model.worldToLocalMatrix * model.right;
        model.Rotate(up, -moveX,Space.World);
        model.Rotate(right, moveY, Space.World);
        startPos = Input.mousePosition;


        if (isSubmit)
        {
            //发送数据
            DialogUIControl.sc.SendInt(NetworkData.SENDROTATION);
            DialogUIControl.sc.SendFloat(model.eulerAngles.x);
            DialogUIControl.sc.SendFloat(model.eulerAngles.y);
            DialogUIControl.sc.SendFloat(model.eulerAngles.z);
        }
    }

    private void OnApplicationQuit()
    {
        //程序退出时关闭连接
        if(DialogUIControl.sc != null)
        {
            DialogUIControl.sc.close();
        } 
    }

}
