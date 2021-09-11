using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public static Crafter instance;

	private void Awake()
	{
		instance = this;
	}

    public Element slot1;
	public Element slot2;

    public Recipies[] recipes;

    public Transform resultsParent;
	public GameObject elementPrefab;
	public GameObject ghostElementPrefab;

	public Animator animator;

    public void AddElement(Element element, int slot)
	{
		if (slot == 1)
		{
			slot1 = element;
		} else if (slot == 2)
		{
			slot2 = element;
		}

		UpdateResult();
	}

    public void RemoveElement(int slot)
	{
		//Debug.Log("Remove from slot " + slot);

		if (slot == 1)
		{
			slot1 = null;
		} else if (slot == 2)
		{
			slot2 = null;
		}

		UpdateResult();
	}

    void UpdateResult()
	{
		ClearPreviousResult();

		Element[] results = GetResults();
		Element[] resultsInInventory = GetResultsInInventory();
		if (results != null && results.Length != 0)
		{
			foreach (Element result in results)
			{
				CreateItem(result);
			}
		}

		if (resultsInInventory != null && resultsInInventory.Length != 0)
		{
			foreach (Element result in resultsInInventory)
			{
				CreateGhostItem(result);
			}
		}
    }

    void CreateItem (Element element)
	{
		GameObject elementObj = Instantiate(elementPrefab, resultsParent);
		ElementsDisplayer display = elementObj.GetComponent<ElementsDisplayer>();
		if (display != null)
			display.Setup(element);
		animator.SetBool("IsCrafted", true);
		ScrollMaster.instance.AddNewCraftElement(slot1, slot2, element);
	}

	void CreateGhostItem (Element element)
	{
		GameObject itemObj = Instantiate(ghostElementPrefab, resultsParent);
		ElementsDisplayer display = itemObj.GetComponent<ElementsDisplayer>();

		if (display != null)
			display.Setup(element);
	}

    Element[] GetResults ()
	{
        
		if (slot1 == null || slot2 == null)
			return null;

		List<Element> elements = new List<Element>();

		foreach (Recipies recipe in recipes)
		{
			if ((recipe.component1 == slot1 && recipe.component2 == slot2) ||
				(recipe.component1 == slot2 && recipe.component2 == slot1))
			{
				if (!Inventory.instance.HasElement(recipe.result))
				{
					elements.Add(recipe.result);
				}
			}
		}

		return elements.ToArray();
	}

	Element[] GetResultsInInventory()
	{
		if (slot1 == null || slot2 == null)
			return null;

		List<Element> elements = new List<Element>();

		foreach (Recipies recipe in recipes)
		{
			if ((recipe.component1 == slot1 && recipe.component2 == slot2) ||
				(recipe.component1 == slot2 && recipe.component2 == slot1))
			{
				if (Inventory.instance.HasElement(recipe.result))
				{
					elements.Add(recipe.result);
				}
			}
		}

		return elements.ToArray();
	}

    void ClearPreviousResult ()
	{
		foreach (Transform child in resultsParent)
		{
			Destroy(child.gameObject);
		}
	}
}
