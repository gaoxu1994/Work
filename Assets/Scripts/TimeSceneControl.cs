using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TimeSceneControl : MonoBehaviour {

    private static bool isActive = true;

    private float startTime;
    //当前场景的名称
    private string ASName = "FirstScene"; 
	//Use this for initialization
	void Start () {
        //本实例不销毁
        DontDestroyOnLoad(gameObject);
        //跳转到第一场景
        SceneManager.LoadScene("FirstScene");
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0))
        {
            startTime = Time.time;
        }
        ASName = SceneManager.GetActiveScene().name;
        //没有处在第一场景并且10秒之内没有反应
        if (ASName != "FirstScene" && ((Time.time - startTime) > 10.0f))
        {
            //如果提交之后
            if (NetworkData.isSubmit)
            {
                Debug.Log("TimeSceneControl" + "Update");
                //发送断开连接信号
                SocketConnect.getSocketInstance().SendInt(NetworkData.SENDDISCONNECT);
                SocketConnect.getSocketInstance().close();
                //结束展示
                NetworkData.isSubmit = false;

            }
            //卸载当前场景
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            //加载第一场景
            SceneManager.LoadScene("FirstScene");
        }
    }



    private void OnApplicationQuit()
    {
        Debug.Log("退出程序连接");
        //程序退出时关闭连接
        if (SocketConnect.getSocketInstance() != null)
        {
            Debug.Log("OnApplicationQuit");
            SocketConnect.getSocketInstance().close();
        }
    }
}
