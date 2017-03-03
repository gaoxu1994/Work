using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public bool dragOnSurfaces = true;
    public static bool isDraging = false;
	private Dictionary<int,GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();
	private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();


    //开始拖拽回调方法
	public void OnBeginDrag(PointerEventData eventData)
	{
       // Debug.Log("OnBeginDrag========================================");
        //寻找父节点的方法
		var canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null)
			return;

		// We have clicked something that can be dragged.
		// What we want to do is create an icon for this.
		m_DraggingIcons[eventData.pointerId] = new GameObject("icon");

		m_DraggingIcons[eventData.pointerId].transform.SetParent (canvas.transform, false);
		m_DraggingIcons[eventData.pointerId].transform.SetAsLastSibling();
		
		var image = m_DraggingIcons[eventData.pointerId].AddComponent<Image>();
		// The icon will be under the cursor.
		// We want it to be ignored by the event system.
		var group = m_DraggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
		group.blocksRaycasts = false;

		image.sprite = GetComponent<Image>().sprite;
		image.SetNativeSize();
		
		if (dragOnSurfaces)
			m_DraggingPlanes[eventData.pointerId] = transform as RectTransform;
		else
			m_DraggingPlanes[eventData.pointerId]  = canvas.transform as RectTransform;
		
        //设置拖动的位置
		SetDraggedPosition(eventData);

        //Debug.Log("OnBeginDrag");
        isDraging = true;

	}

    //拖动过程中回调方法
	public void OnDrag(PointerEventData eventData)
	{
		if (m_DraggingIcons[eventData.pointerId] != null)
            //设置拖动的位置
			SetDraggedPosition(eventData);
	}

	private void SetDraggedPosition(PointerEventData eventData)
	{
		if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
			m_DraggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;
		
		var rt = m_DraggingIcons[eventData.pointerId].GetComponent<RectTransform>();
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = m_DraggingPlanes[eventData.pointerId].rotation;
		}
	}

    //拖动结束回调方法
	public void OnEndDrag(PointerEventData eventData)
	{
        //Debug.Log("OnEndDrag===================================");
        if (m_DraggingIcons[eventData.pointerId] != null)
			Destroy(m_DraggingIcons[eventData.pointerId]);

		m_DraggingIcons[eventData.pointerId] = null;
        isDraging = false;

    }

    //在父类中寻找对应的组件
	static public T FindInParents<T>(GameObject go) where T : Component
	{
        //如果传入的值为空
		if (go == null) return null;

        //在当前对象寻找组件
		var comp = go.GetComponent<T>();
		if (comp != null)
			return comp;
		//获得父对象
		var t = go.transform.parent;

		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}
