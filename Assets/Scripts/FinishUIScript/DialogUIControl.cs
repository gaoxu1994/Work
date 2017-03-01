using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogUIControl : MonoBehaviour {

    [HideInInspector]
    public static SocketConnect sc;
    private Transform InputButtonRoot;  //输入按钮根节点
    private Button SubmitButton;    //提交按钮
    private Button AperButton;      //光圈按钮
    private InputField NameInput;   //获得输入焦点
    //协程运行标志位
    private bool flag = false;

    private Transform OkButton;
    private Transform BackButton;



    // Use this for initialization
    void Start () {
        OkButton = transform.parent.Find("OkButton");
        BackButton = transform.parent.Find("BackButton");
        //获得输入按钮根节点
        InputButtonRoot = transform.Find("InputButtonRoot");
        //光圈按钮
        AperButton = InputButtonRoot.Find("AperButton").GetComponent<Button>();
        //提交按钮
        SubmitButton = transform.Find("SubmitButton").GetComponent<Button>();
        //注册监听
        EventTriggerListener.Get(AperButton.gameObject).onClick = OnAperClick;
        //获的输入框
        NameInput = transform.Find("NameInput").GetComponent<InputField>();
        NameInput.interactable = false;

    }
    //点击光圈事件回调方法
	void OnAperClick(GameObject go)
    {
        InputButtonRoot.gameObject.SetActive(false);
        //注册提交按钮监听
        EventTriggerListener.Get(SubmitButton.gameObject).onClick = OnSubmitClick;
        NameInput.interactable = true;
        //获得焦点
        NameInput.ActivateInputField();
    }

    //点击提交事件
    void OnSubmitClick(GameObject go)
    {
        if (flag)   //协程已经启动
        {
            return;
        }
        if (sc == null)
        {
            //获得连接实例
            sc = SocketConnect.getSocketInstance();
            ModelViewControl.isSubmit = true;
            //发送请求链接信号
            sc.SendInt(NetworkData.SENDCONNECT);
            ////数据
            ////交通工具类型
            //sc.SendInt((int)NetworkData.TypeTraffic);
            ////种类
            //sc.SendInt((int)NetworkData.TypeSign);
            ////车辆颜色
            //sc.SendInt((int)NetworkData.TypeColor);
            flag = true;
            StartCoroutine(WaitSign());
        }
        
    }
    IEnumerator WaitSign()
    {
        while (flag)
        {
            if (NetworkData.isSucceed)  //是否成功连接
            {
                Debug.Log("发送完成的数据");
                sc.SendInt(NetworkData.SENDDATA);
                //交通工具类型
                sc.SendInt((int)NetworkData.TypeTraffic);
                //种类
                sc.SendInt((int)NetworkData.TypeSign);
                //车辆颜色
                sc.SendInt((int)NetworkData.TypeColor);

                NetworkData.isSucceed = false;
                flag = false;
                gameObject.SetActive(false);
                OkButton.gameObject.SetActive(false);
                BackButton.gameObject.SetActive(false);

            }
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    



}
