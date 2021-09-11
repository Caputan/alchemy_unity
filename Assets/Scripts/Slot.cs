using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject elementObj;

	public int slot;

    public void OnDrop(PointerEventData eventData)
	{
		if (!elementObj)
		{
			elementObj = DragAndDrop.objBeingDragged;
			elementObj.transform.SetParent(transform);
			elementObj.transform.position = transform.position;

			Crafter.instance.AddElement(DragAndDrop.GetItemBeingDragged(), slot);
		}
	}

    void Update ()
	{
		if (elementObj != null)
		{
			if (elementObj.transform.parent != transform)
			{
				Crafter.instance.RemoveElement(slot);
				elementObj = null;
			}
		}
	}
}
