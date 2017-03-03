using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;        //����ͼƬ
	//public Image receivingImage;        //����ͼƬ


    private Object preb;//���ص�Ԥ�Ƽ�

    private Transform model;
    private GameObject RTCamera;
    //ͷ�����
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

    //��������
    public void OnDrop(PointerEventData data)
	{

        //if (receivingImage == null)
        //    return;

        ////����ͼƬ
        //Sprite dropSprite = GetDropSprite(data);
        //if (dropSprite != null)
        //    receivingImage.overrideSprite = dropSprite;

        if (model.Find("HeadCom") != null)
        {
            Destroy(model.Find("HeadCom").gameObject);
        }
        //Debug.Log("===============================");
        ////ʵ�������
        HeadCom = Instantiate(preb) as GameObject;
        HeadCom.transform.parent = model;
        HeadCom.transform.localPosition = new Vector3(0, 1, 0);
        HeadCom.name = "HeadCom";



        Debug.Log("OnDrop");



    }

    //���ָ����뵱ǰGameObject
	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		//Sprite dropSprite = GetDropSprite (data);
		//if (dropSprite != null)
		//	containerImage.color = highlightColor;
	}

    //���ָ���˳���ǰGameObject
	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		//containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
        //��ǰ��ק������
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

        //�����ק�����ϵĶ�dragMe���
        var dragMe = originalObj.GetComponent<DragMe>();
        if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}
}
