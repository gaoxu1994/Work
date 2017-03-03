using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;        //容器图片
	//public Image receivingImage;        //接收图片


    private Object preb;//加载的预制件

    private Transform model;
    private GameObject RTCamera;
    //头部组件
    private GameObject HeadCom;



    public void OnEnable ()
	{
        

    }
    private void Start()
    {
        RTCamera = GameObject.Find("RTCamera");
        model = RTCamera.transform.Find("Models");
        preb = Resources.Load("Sphere", typeof(GameObject));

    }

    //丢弃方法
    public void OnDrop(PointerEventData data)
	{

        //if (receivingImage == null)
        //    return;

        ////设置图片
        //Sprite dropSprite = GetDropSprite(data);
        //if (dropSprite != null)
        //    receivingImage.overrideSprite = dropSprite;

        if (model.Find("HeadCom") != null)
        {
            Destroy(model.Find("HeadCom").gameObject);
        }
        //Debug.Log("===============================");
        ////实例化组件
        HeadCom = Instantiate(preb) as GameObject;
        HeadCom.transform.parent = model;
        HeadCom.transform.localPosition = new Vector3(0, 1, 0);
        HeadCom.name = "HeadCom";



        Debug.Log("OnDrop");



    }

    //鼠标指针进入当前GameObject
	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		//Sprite dropSprite = GetDropSprite (data);
		//if (dropSprite != null)
		//	containerImage.color = highlightColor;
	}

    //鼠标指针退出当前GameObject
	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		//containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
        //当前拖拽的物体
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

        //获得拖拽物体上的额dragMe组件
        var dragMe = originalObj.GetComponent<DragMe>();
        if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}
}
