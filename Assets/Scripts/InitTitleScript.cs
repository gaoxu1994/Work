using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(FindInChildren))]
public class InitTitleScript : MonoBehaviour {

    public Sprite[] TitleSprites;
    private Image TitleSprit;
    // Use this for initialization
    void Start () {
		if(TitleSprites.Length == 0)
        {
            Debug.LogError("BgSprites Don`t instantiate");
        }
        //获得标题Image
        TitleSprit = transform.Find("Title").gameObject.GetComponent<Image>();
        //初始化数据方法
        InitData();
	}
    void InitData()
    {
        switch (NetworkData.TypeSign)
        {
            case SignType.SedanOrFighter:   //战斗机或者轿车
                TitleSprit.sprite = TitleSprites[0];
                break;
            case SignType.SUVOrPropeller:   //螺旋桨飞机或者SUV
                TitleSprit.sprite = TitleSprites[1];
                break;
            case SignType.TruckOrAirliner:  //客机或者卡车
                TitleSprit.sprite = TitleSprites[2];
                break;
        }
    }

}
