using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectAirplane : MonoBehaviour {

    #region
    private Button FighterButton;   //战斗机Button
    private Button PropellerButton; //螺旋桨飞机Button
    private Button AirlinerButton; //客机Button
    private Button BackButton;      //返回Button
    #endregion
    #region Transform
    private Transform FirstCanvas;
    #endregion
    // Use this for initialization
    void Start () {
        FirstCanvas = transform.parent.Find("FirstCanvas");
        //获取Button
        FighterButton = transform.Find("FighterButton").GetComponent<Button>();
        PropellerButton = transform.Find("PropellerButton").GetComponent<Button>();
        AirlinerButton = transform.Find("AirlinerButton").GetComponent<Button>();
        BackButton = transform.Find("BackButton").GetComponent<Button>();
        //注册监听
        EventTriggerListener.Get(BackButton.gameObject).onClick = OnBackClick;
        EventTriggerListener.Get(FighterButton.gameObject).onClick = OnFighterClick;
        EventTriggerListener.Get(PropellerButton.gameObject).onClick = OnPropellerClick;
        EventTriggerListener.Get(AirlinerButton.gameObject).onClick = OnAirlinerClick;
    }
    //战斗机
    void OnFighterClick(GameObject go)
    {
        NetworkData.TypeSign = SignType.SedanOrFighter;
        Debug.Log("战斗机");
        //跳转到设计飞机的场景
        SceneManager.LoadScene("DesignAirplaneScene");
    }
    //螺旋桨飞机
    void OnPropellerClick(GameObject go)
    {
        //设置传递的信号
        NetworkData.TypeSign = SignType.SUVOrPropeller;
        Debug.Log("螺旋桨飞机");
        SceneManager.LoadScene("DesignAirplaneScene");
    }
    //客机
    void OnAirlinerClick(GameObject go)
    {
        NetworkData.TypeSign = SignType.TruckOrAirliner;
        Debug.Log("客机");
        SceneManager.LoadScene("DesignAirplaneScene");

    }

    //返回按钮回调
    void OnBackClick(GameObject go)
    {
        gameObject.SetActive(false);
        FirstCanvas.gameObject.SetActive(true);
    }
}
