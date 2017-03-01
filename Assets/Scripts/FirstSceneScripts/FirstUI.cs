using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstUI : MonoBehaviour {
    #region Button
    private Button airplayButton;
    private Button carButton;
    #endregion

    #region Transform
    private Transform AirPlaneCanvas;
    private Transform CarCanvas;
    #endregion

    // Use this for initialization
    void Start () {

        AirPlaneCanvas = transform.parent.Find("AirPlaneCanvas");
        CarCanvas = transform.parent.Find("CarCanvas");

        airplayButton = transform.Find("airplaneButton").gameObject.GetComponent<Button>();
        carButton = transform.Find("carButton").gameObject.GetComponent<Button>();
        EventTriggerListener.Get(airplayButton.gameObject).onClick = airplayClick;
        EventTriggerListener.Get(carButton.gameObject).onClick = carClick;
    }
    //飞机按钮回掉方法
    void airplayClick(GameObject go)
    {
        gameObject.SetActive(false);
        NetworkData.TypeTraffic = TrafficType.AirPlane;
        AirPlaneCanvas.gameObject.SetActive(true);
    }
    //汽车回调方法
    void carClick(GameObject go)
    {
        gameObject.SetActive(false);
        NetworkData.TypeTraffic = TrafficType.Car;
        CarCanvas.gameObject.SetActive(true);
    }

}
