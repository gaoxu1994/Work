using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour {

    #region

    private Button SedanButton;     //轿车
    private Button SUVButton;       //SUV
    private Button TruckButton;    //卡车
    private Button BackButton;      //返回Button
    #endregion
    #region Transform
    private Transform FirstCanvas;
    #endregion
    // Use this for initialization
    void Start () {
        FirstCanvas = transform.parent.Find("FirstCanvas");
        //获得Button
        BackButton = transform.Find("BackButton").GetComponent<Button>();
        SedanButton = transform.Find("SedanButton").GetComponent<Button>();
        SUVButton = transform.Find("SUVButton").GetComponent<Button>();
        TruckButton = transform.Find("TruckButton").GetComponent<Button>();
        //注册监听
        EventTriggerListener.Get(BackButton.gameObject).onClick = OnBackClick;
        EventTriggerListener.Get(SedanButton.gameObject).onClick = OnSedanClick;
        EventTriggerListener.Get(SUVButton.gameObject).onClick = OnSUVClick;
        EventTriggerListener.Get(TruckButton.gameObject).onClick = OnTruckClick;
    }

    //轿车
    void OnSedanClick(GameObject go)
    {
        NetworkData.TypeSign = SignType.SedanOrFighter;
        SceneManager.LoadScene("DesignCarScene");
        Debug.Log("轿车");
    }

    //SUV
    void OnSUVClick(GameObject go)
    {
        //设置传递的信号
        NetworkData.TypeSign = SignType.SUVOrPropeller;
        SceneManager.LoadScene("DesignCarScene");
        Debug.Log("SUV");
    }
    //卡车
    void OnTruckClick(GameObject go)
    {
        NetworkData.TypeSign = SignType.TruckOrAirliner;
        SceneManager.LoadScene("DesignCarScene");
        Debug.Log("卡车");
    } 

    void OnBackClick(GameObject go)
    {
        gameObject.SetActive(false);
        FirstCanvas.gameObject.SetActive(true);
    }
}
