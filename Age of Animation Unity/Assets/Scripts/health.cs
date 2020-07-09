﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class health : MonoBehaviour {

    
    public float unitsStartingHealth;
    public float unitsCurrentHealth;

    public float deathwait = .25f;
    public GameObject thisUnitsDeathSprite;

    score Score;
    characterSpawner Spawner;
    HealthBar HpBar;


    void Start()
    {
        HpBar = gameObject.GetComponentInChildren<HealthBar>();
        Score = FindObjectOfType<score>();
        Spawner = FindObjectOfType<characterSpawner>();
    }


    void StartHealth()
    {
        unitsCurrentHealth = unitsStartingHealth;
    }


    public void TakeDamage(int damage)
    {        
        unitsCurrentHealth -= damage;

        if (unitsCurrentHealth <= 0) { Die(); }

        else { HpBar.UpdateUnitsHealthBar(); }
    }


    void Die()
    {
        Score.ChangeTreasury("increase", this.gameObject.name, this.gameObject.tag);
        Score.ChangeExperience("increase", this.gameObject.name, this.gameObject.tag);

        var clone = Instantiate(thisUnitsDeathSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(clone, deathwait);

        if (gameObject.tag == "Player2")
        {
            if (gameObject.name == "Character1")
            { Spawner.inGameUnit1Bots.Remove(gameObject.name); }

            else if (gameObject.name == "Character2")
            { Spawner.inGameUnit2Bots.Remove(gameObject.name); }

            else if (gameObject.name == "Character3")
            { Spawner.inGameUnit3Bots.Remove(gameObject.name); }

            Spawner.UpdateUnitCount();
        }
    }

}
