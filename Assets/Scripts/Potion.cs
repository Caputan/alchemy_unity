using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PotionType
{
    HEAL,
    BUFF,
    DEBUFF,
    PROJECTILE
}

public enum PotionEffect
{
    REGEN,
    STRENGTH,
    AGILITY,
    INTELLECT,
    DEBUFF,
    DAMAGE
}

[System.Serializable]
public class Potion
{

    public int potionId;
    public string potionName;

    public PotionType potionType;

    public float potionDamage;

    public int potionCount;

    public PotionEffect potionEffect;
}
