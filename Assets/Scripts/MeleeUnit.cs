﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        unitHP = 1000;
        unitMaxHP = unitHP;
        unitAtk = 5;
        unitRange = 1;
        unitSpeed = 1;
        unitTeam = Random.Range(0, 2);
        GetComponent<MeshRenderer>().material = unitMat[unitTeam];
        switch (unitTeam)
        {
            case 0:
                gameObject.tag = "Team 1";
                break;
            case 1:
                gameObject.tag = "Team 2";
                break;
        }
    }
}
