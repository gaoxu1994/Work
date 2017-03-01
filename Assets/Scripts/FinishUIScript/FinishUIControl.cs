using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUIControl : MonoBehaviour {

    private Button BackButton;      //返回按钮
    private Button OkButton;        //确定按钮
    private Transform canvas;       //上一级菜单
    private Transform DialogUI;   //对话框显示界面

    // Use this for initialization
    void Start () {

        canvas = transform.parent.Find("SelectColorCanvas");
        BackButton = transform.Find("BackButton").GetComponent<Button>();
        OkButton = transform.Find("OkButton").GetComponent<Button>();

        DialogUI = transform.Find("DialogUI");
        //注册监听
        EventTriggerListener.Get(BackButton.gameObject).onClick = OnBackClick;
        EventTriggerListener.Get(OkButton.gameObject).onClick = OnOkClick;
    }


    //点击返回按钮
    void OnBackClick(GameObject go)
    {
        if(go.GetComponent<Button>().enabled == true)
        {
            gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
        }
    }

    //点击确定按钮
    void OnOkClick(GameObject go)
    {
        if (go.GetComponent<Button>().enabled == true)
        {
            DialogUI.gameObject.SetActive(true);
            BackButton.enabled = false;
            OkButton.enabled = false;
        }
    }
}
