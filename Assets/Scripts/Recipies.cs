using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipies : ScriptableObject
{
    public Element component1;
    public Element component2;

    public Element result;
}
