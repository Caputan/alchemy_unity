using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject objBeingDragged;
	public static Element GetItemBeingDragged(){
		return objBeingDragged.GetComponent<ElementsDisplayer>().element;
	}

    Vector3 startPosition;
    Transform startParent;

    Transform itemDraggerParent;
	CanvasGroup canvasGroup;

    void Start()
    {
		canvasGroup = GetComponent<CanvasGroup>();
		itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
    }

	public void OnBeginDrag(PointerEventData eventData)
	{
		objBeingDragged = gameObject;
	
		startPosition = transform.position;
		startParent = transform.parent;

		transform.SetParent(itemDraggerParent);

		canvasGroup.blocksRaycasts = false;
	}

    public void OnDrag(PointerEventData pointerEvent)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData pointerEvent)
    {
		objBeingDragged = null;
		canvasGroup.blocksRaycasts = true;

		if(transform.parent == itemDraggerParent)
		{
			transform.position = startPosition;
			transform.SetParent(startParent); 
		}
    }
}

