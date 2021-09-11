using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class DataToSave
{
    
    public string playerName;

    public string date;

    public float playerMaxHP;
    public float playerCurrentHP;

    public List<Skill> playerCurrentSkills;
    public List<Potion> playerCurrentPotions;

    public string currentLevelName;

    public DataToSave(Player player)
    {
        playerName = player.unitName;

        date = DateTime.Now.ToString();

        playerMaxHP = player.maxHP;
        playerCurrentHP = player.currentHP;

        playerCurrentSkills = player.skills;

        playerCurrentPotions = player.potions;

        currentLevelName = SceneManager.GetActiveScene().name;
    }
}
