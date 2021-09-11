using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCraftDisplay : MonoBehaviour
{
    public Element slot1;
    public Element slot2;

    public GameObject elementPrefab;
    public Transform resultsParent;
    public Transform slot1Parent;
    public Transform slot2Parent;

    public List<Element> recElements;

    public void AddElement(Element _slot1, Element _slot2, Element result)
    {
        slot1 = _slot1;
        recElements.Add(slot1);
        GameObject elementObj = Instantiate(elementPrefab, slot1Parent);
        ElementsDisplayer display = elementObj.GetComponent<ElementsDisplayer>();
        if (display != null)
            display.Setup(slot1);
        slot2 = _slot2;
        recElements.Add(slot2);
        GameObject elementObj1 = Instantiate(elementPrefab, slot2Parent);
        ElementsDisplayer display1 = elementObj1.GetComponent<ElementsDisplayer>();
        if (display1 != null)
            display1.Setup(slot2);
        recElements.Add(result);
        GameObject elementObj2 = Instantiate(elementPrefab, resultsParent);
        ElementsDisplayer display2 = elementObj2.GetComponent<ElementsDisplayer>();
        if (display2 != null)
            display2.Setup(result);
    }
}
