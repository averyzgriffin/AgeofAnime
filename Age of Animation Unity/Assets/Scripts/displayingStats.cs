﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayingStats : MonoBehaviour {

    public Text healthText;
    public Text goldText;
    public Text expText;

    public score Score;
    public baseHealth Health;


    void Update ()
    {
        healthText.text = "Health: " + Health.currentHealth;

        if (this.gameObject.name == "P1 Health, Experience, Gold Parent")
        {
            goldText.text = "P1 Gold: " + Score.P1Gold;
        }
        else if (this.gameObject.name == "P2 Health, Experience, Gold Parent")
        {
            goldText.text = "P2 Gold: " + Score.P2Gold;
        }


        if (this.gameObject.name == "P1 Health, Experience, Gold Parent")
        {
            expText.text = "P1 Exp: " + Score.P1Exp;
        }
        else if (this.gameObject.name == "P2 Health, Experience, Gold Parent")
        {
            expText.text = "P2 Exp: " + Score.P2Exp;
        }
    }
}
