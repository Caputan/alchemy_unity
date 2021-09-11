using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SkillType
{
	PHYSICAL,
	FIRE,
	WATER,
	EARTH,
	AIR
}

public enum SkillEffect
{
	NONE,
	BURNING,
	COLD,
	FREEZE
}

[System.Serializable]
public class Skill 
{
	public int skillId;

	//public Image spellIcon;
	//public Sprite spellSprite;

	public SkillType skillType;
	public float skillDamage;

	public SkillEffect skillEffect;
}
