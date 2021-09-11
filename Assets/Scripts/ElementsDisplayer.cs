using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ElementsDisplayer : MonoBehaviour
{
	public Element element;
	public Image icon;  

	public void Setup (Element _element)
	{
		element = _element;
		icon.sprite = element.icon;
		// nameText.text = element.name;
	}
}
