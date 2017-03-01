using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//选择飞机颜色控制
public class SelectAirplaneColorControl : MonoBehaviour {

    #region Button
    private Button BackButton;
    private Button OkButton;

    private Button BlackButton;
    private Button RedButton;
    private Button BlueButton;
    private Button YellowButton;
    #endregion

    #region Transform
    private Transform RtCamera;
    private MeshRenderer modelRender;

    #endregion


    private Transform canvasUP;
    private Transform canvasNext;

    // Use this for initialization
    void Start () {


        //获得显示的模型
        RtCamera = transform.parent.Find("RTCamera");
        modelRender = RtCamera.Find("Models").GetComponent<MeshRenderer>();

        canvasUP = transform.parent.Find("DesignCanvas");
        canvasNext = transform.parent.Find("FinishCanvas");

        //获得Button组件
        BackButton = transform.Find("BackButton").GetComponent<Button>();
        OkButton = transform.Find("OkButton").GetComponent<Button>();

        BlackButton = transform.Find("BlackButton").GetComponent<Button>();
        RedButton = transform.Find("RedButton").GetComponent<Button>();
        BlueButton = transform.Find("BlueButton").GetComponent<Button>();
        YellowButton = transform.Find("YellowButton").GetComponent<Button>();


        //注册监听
        EventTriggerListener.Get(BackButton.gameObject).onClick = OnBackClick;
        EventTriggerListener.Get(OkButton.gameObject).onClick = OnOkClick;

        EventTriggerListener.Get(BlackButton.gameObject).onClick = OnBlackClick;
        EventTriggerListener.Get(RedButton.gameObject).onClick = OnRedClick;
        EventTriggerListener.Get(BlueButton.gameObject).onClick = OnBlueClick;
        EventTriggerListener.Get(YellowButton.gameObject).onClick = OnYellowClick;
    }


    void OnBlackClick(GameObject go)
    {
        modelRender.material.color = new Color(0, 0, 0);
    }
    void OnRedClick(GameObject go)
    {
        modelRender.material.color = new Color(1, 0, 0);
    }
    void OnBlueClick(GameObject go)
    {
        modelRender.material.color = new Color(0, 0, 1);
    }
    void OnYellowClick(GameObject go)
    {
        modelRender.material.color = new Color(1, 1, 0);
    }



    //点击返回按钮
    void OnBackClick(GameObject go)
    {
        // Debug.Log("Select Color Back Log");
        gameObject.SetActive(false);
        canvasUP.gameObject.SetActive(true);
    }

    //点击确定按钮
    void OnOkClick(GameObject go)
    {
        //  Debug.Log("Select Color OK Log");
        gameObject.SetActive(false);
        canvasNext.gameObject.SetActive(true);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
