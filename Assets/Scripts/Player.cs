using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    public List<Skill> skills;
    public List<Potion> potions;

    public GameObject skillPrefab;

    private GameObject enemy;

    public int allPotionsCount;

    public void Start()
    {
        enemy = GameObject.Find("Enemy(Clone)");

        SetupSkills();
        SetupPotions();
    }

    public void Heal(float ammount)
    {
        currentHP += ammount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void SetupSkills()
    {
        for(int i = 0; i < skills.Count; i++)
        {
            skills[i].skillId = i; 
        }
    }

    public void SetupPotions()
    {
        for (int i = 0; i < potions.Count; i++)
        {
            potions[i].potionId = i;
        }
    }

    public void AddNewSkill(Skill skill)
    {
        skills.Add(skill);
        skills[skills.Count - 1].skillId = skills.Count - 1;
        //skills[skills.Count - 1].skillName = skill.skillName;
        skills[skills.Count - 1].skillType = skill.skillType;
        skills[skills.Count - 1].skillDamage = skill.skillDamage;
        skills[skills.Count - 1].skillEffect = skill.skillEffect;
    }

    public void AddNewPotion(Potion potion)
    {
        potions.Add(potion);
        potions[potions.Count - 1].potionId = potions.Count - 1;
        potions[potions.Count - 1].potionName = potion.potionName;
        potions[potions.Count - 1].potionType = potion.potionType;
        potions[potions.Count - 1].potionDamage = potion.potionDamage;
        potions[potions.Count - 1].potionEffect = potion.potionEffect;
    }

    public bool UseSkill(int skillId)
    {
        Vector3 dir = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;

        GameObject skill = Instantiate(skillPrefab, transform.position, Quaternion.AngleAxis(angle, new Vector3(0,0,1)));
        skill.GetComponent<SkillDisplayer>().ShowSkill(skills[skillId]);
        skill.GetComponent<SkillDisplayer>().Move(dir);

        return enemy.GetComponent<Enemy>().TakeDamage(skills[skillId].skillDamage);
    }

    public void UsePotion(int potionId)
    {

    }
}
