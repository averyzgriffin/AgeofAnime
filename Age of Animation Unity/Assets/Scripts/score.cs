﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class score : MonoBehaviour
{

    public float P1Gold;
    public float P2Gold;
    public float P1Exp;
    public float P2Exp;

    public float p1Unit1cost;
    public float p1Unit2cost;
    public float p1Unit3cost;

    public float p2Unit1cost;
    public float p2Unit2cost;
    public float p2Unit3cost;

    public float P1EvolveXPCost;
    public float P2EvolveXPCost;

    private float unitKilledXPReward = 2.5f;
    private float unitDeathXPReward = 0.8f;
    private float unitKilledGoldReward = 1.25f;
    private float unitDeathGoldReward = 0.1f; 

    private string Char1 = "Character1";
    private string Char2 = "Character2";
    private string Char3 = "Character3";

    private List<float> unit1CostList = new List<float>();
    private List<float> unit2CostList = new List<float>();
    private List<float> unit3CostList = new List<float>();

    private List<float> evolveReqs = new List<float>();



    #region Call Backs
    private void Awake()
    {
        unit1CostList.AddRange(new float[] { 15, 120, 9000, 90000, 500000 });         // these numbers are the age of war 1 numbers
        unit2CostList.AddRange(new float[] { 30, 240, 20000, 200000, 750000 });
        unit3CostList.AddRange(new float[] { 100, 800, 70000, 700000, 1000000 });

        evolveReqs.AddRange(new float[] { 1200, 20000, 300000, 2000000, 1000000000 });
    }

    void Start()
    {
        P1Gold = 80;
        P2Gold = 150;

        p1Unit1cost = unit1CostList[0];
        p1Unit2cost = unit2CostList[0];
        p1Unit3cost = unit3CostList[0];

        p2Unit1cost = unit1CostList[0];
        p2Unit2cost = unit2CostList[0];
        p2Unit3cost = unit3CostList[0];

        P1Exp = 0;
        P2Exp = 0;

        P1EvolveXPCost = P2EvolveXPCost = evolveReqs[0];

    }
    #endregion


    private void Update()
    {

    }


    #region Changing Gold Reqs
    public void ChangeGoldReqs(string player, int age)
    {
        if (player == "P1")
        {
            p1Unit1cost = unit1CostList[age];
            p1Unit2cost = unit2CostList[age];
            p1Unit3cost = unit3CostList[age];
        }

        if (player == "P2")
        {
            p2Unit1cost = unit1CostList[age];
            p2Unit2cost = unit2CostList[age];
            p2Unit3cost = unit3CostList[age];
        }
    }
    #endregion


    #region Changing Gold Treasury
    public void ChangeTreasury(string function, string name, string tag)
    {
        if (function == "increase")
        {
            if (tag == "Player2")
            {
                if (name == Char1)
                {
                    P1Gold = P1Gold + (p1Unit1cost * unitKilledGoldReward);
                    P2Gold = P2Gold + (p2Unit1cost * unitDeathGoldReward);
                }

                if (name == Char2)
                {
                    P1Gold = P1Gold + (p1Unit2cost * unitKilledGoldReward);
                    P2Gold = P2Gold + (p2Unit2cost * unitDeathGoldReward);
                }

                if (name == Char3)
                {
                    P1Gold = P1Gold + (p1Unit3cost * unitKilledGoldReward);
                    P2Gold = P2Gold + (p2Unit3cost * unitDeathGoldReward);
                }
            }

            if (tag == "Player1")
            {
                if (name == Char1)
                {
                    P2Gold = P2Gold + (p2Unit1cost * unitKilledGoldReward * 2);
                    P1Gold = P1Gold + (p1Unit1cost * unitDeathGoldReward);
                }

                if (name == Char2)
                {
                    P2Gold = P2Gold + (p2Unit2cost * unitKilledGoldReward * 2);
                    P1Gold = P1Gold + (p1Unit2cost * unitDeathGoldReward);
                }

                if (name == Char3)
                {
                    P2Gold = P2Gold + (p2Unit3cost * unitKilledGoldReward * 2);
                    P1Gold = P1Gold + (p1Unit3cost * unitDeathGoldReward);
                }
            }
        }
        
        if (function == "decrease")
        {
            if (tag == "Player1")
            {
                if (name == Char1) 
                {
                    P1Gold = P1Gold - p1Unit1cost;
                }

                if (name == Char2)
                {
                    P1Gold = P1Gold - (p1Unit2cost);
                }

                if (name == Char3)
                {
                    P1Gold = P1Gold - (p1Unit3cost);
                }
            }

            if (tag == "Player2")
            {
                if (name == Char1)
                {
                    P2Gold = P2Gold - (p2Unit1cost);
                }

                if (name == Char2)
                {
                    P2Gold = P2Gold - (p2Unit2cost);
                }

                if (name == Char3)
                {
                    P2Gold = P2Gold - (p2Unit3cost);
                }
            }




        }
    }
    #endregion


    #region Changing Experience Reqs
    public void ChangeExperienceReqs(string player, int age)
    {

        if (player == "P1")
        {
            P1EvolveXPCost = evolveReqs[age];
        }

        if (player == "P2")
        {
            P2EvolveXPCost = evolveReqs[age];
        }
    }
    #endregion


    #region Changing Experience
    public void ChangeExperience(string function, string name, string tag)
    {

        if (function == "increase")
        {
            if (tag == "Player2")
            {
                if (name == Char1)
                {
                    P1Exp = P1Exp + (p1Unit1cost * unitKilledXPReward);
                    P2Exp = P2Exp + (p2Unit1cost * unitKilledXPReward / 3);
                }

                if (name == Char2)
                {
                    P1Exp = P1Exp + (p1Unit2cost * unitKilledXPReward);
                    P2Exp = P2Exp + (p2Unit2cost * unitKilledXPReward / 3);
                }

                if (name == Char3)
                {
                    P1Exp = P1Exp + (p1Unit3cost * unitKilledXPReward);
                    P2Exp = P2Exp + (p2Unit3cost * unitKilledXPReward / 3);
                }

                else
                {
                }
            }

            if (tag == "Player1")
            {
                if (name == Char1)
                {
                    P2Exp = P2Exp + (p2Unit1cost * unitKilledXPReward);
                    P1Exp = P1Exp + (p1Unit1cost * unitKilledXPReward / 3);
                }

                if (name == Char2)
                {
                    P2Exp = P2Exp + (p2Unit2cost * unitKilledXPReward);
                    P1Exp = P1Exp + (p1Unit2cost * unitKilledXPReward / 3);
                }

                if (name == Char3)
                {
                    P2Exp = P2Exp + (p2Unit3cost * unitKilledXPReward);
                    P1Exp = P1Exp + (p1Unit3cost * unitKilledXPReward / 3);
                }
            }
        }


        if (function == "decrease")
        {
            if (tag == "P1")
            {
                P1Exp = 0;
            }

            if (tag == "P2")
            {
                P2Exp = 0;
            }
        }
    }
    #endregion
}