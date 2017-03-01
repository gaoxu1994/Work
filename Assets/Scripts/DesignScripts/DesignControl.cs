using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesignControl : MonoBehaviour {

    private Button BackButton;
    private Button OkButton;
    private Transform canvas;

    void Start () {

        canvas = transform.parent.Find("SelectColorCanvas");

        BackButton = transform.Find("BackButton").GetComponent<Button>();
        OkButton = transform.Find("OkButton").GetComponent<Button>();
        //注册监听
        EventTriggerListener.Get(BackButton.gameObject).onClick = OnBackClick;
        EventTriggerListener.Get(OkButton.gameObject).onClick = OnOkClick;
    }

    // Update is called once per frame
    void Update () {
		
	}
    //点击返回按钮
    void OnBackClick(GameObject go)
    {
        SceneManager.LoadScene("FirstScene");
    }

    //点击确定按钮
    void OnOkClick(GameObject go)
    {
        gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }
}
