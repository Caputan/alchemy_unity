using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaster : MonoBehaviour
{
    public static ScrollMaster instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject scrollCraftPrefab;


    public void AddNewCraftElement(Element _slot1, Element _slot2, Element result)
    {
        GameObject craftObj = Instantiate(scrollCraftPrefab, transform);
        ScrollCraftDisplay scrCraft = craftObj.GetComponent<ScrollCraftDisplay>();
        // if(scrCraft.slot1 == null && scrCraft.slot2 == null)
            scrCraft.AddElement(_slot1, _slot2, result);
    }
}
