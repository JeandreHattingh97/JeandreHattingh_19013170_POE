using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        unitHP = 1000;
        unitMaxHP = unitHP;
        unitAtk = 5;
        unitRange = 2;
        unitSpeed = 1;
        unitTeam = 2;
        GetComponent<MeshRenderer>().material = unitMat[unitTeam];
        switch (unitTeam)
        {
            case 0:
                gameObject.tag = "Team 1";
                break;
            case 1:
                gameObject.tag = "Team 2";
                break;
            case 2:
                gameObject.tag = "Team 3";
                break;
        }
    }
}
