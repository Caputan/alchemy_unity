using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDropHandler
{
    public static Inventory instance;

	private void Awake()
	{
		instance = this;
	}

    public List<Element> elements;
	public List<Element> startElements;

    public GameObject elementPrefab;
	public Transform elementPool;

	public Animator animator;

	private void Start()
	{
		foreach (Element element in startElements)
		{
			AddElement(element, true);
		}
	}

    public void AddElement (Element element, bool startItem)
	{
		AssignElement(element);

		GameObject itemObj = Instantiate(elementPrefab, elementPool);
		ElementsDisplayer display = itemObj.GetComponent<ElementsDisplayer>();
		if (display != null)
			display.Setup(element);

	}

	public void AssignElement (Element element)
	{
		elements.Add(element);
		// Unlocks.instance.OnItemAdded(item);
	}

    public void RemoveItem (Element element)
	{
		elements.Remove(element);
	}

    public bool HasElement (Element element)
	{
		return elements.Contains(element);
	}

    public void OnDrop(PointerEventData eventData)
	{
		if (DragAndDrop.objBeingDragged == null)
			return;
		animator.SetBool("IsCrafted", false);
		DragAndDrop.objBeingDragged.transform.SetParent(transform);

		Element item = DragAndDrop.GetItemBeingDragged();

		if (!HasElement(item))
			AssignElement(item);
	}
}
