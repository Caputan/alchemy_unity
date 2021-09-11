using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public int unitDamage;

    public float maxHP;
    public float currentHP;

    public bool TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public bool Attack(Unit unit)
    {
        return unit.TakeDamage(this.unitDamage);
    }
}
