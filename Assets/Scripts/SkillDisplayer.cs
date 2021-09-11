using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDisplayer : MonoBehaviour
{
	public Skill skill;
	private Image icon;
	private Sprite sprite;

	public void Move(Vector2 direction)
	{
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		rb.AddForce(direction * 5f, ForceMode2D.Impulse);
	}

	public void Setup(Skill _skill)
	{
		skill = _skill;
		//icon = skill.spellIcon;
		// nameText.text = element.name;
	}

	public void ShowSkill(Skill _skill)
	{
		skill = _skill;
		//this.GetComponent<SpriteRenderer>().sprite = skill.spellSprite;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}
}
