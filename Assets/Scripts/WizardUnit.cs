using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        unitHP = 10;
        unitMaxHP = unitHP;
        unitAtk = 1;
        unitRange = 2;
        unitSpeed = 1;
        unitTeam = 2;
        GetComponent<MeshRenderer>().material = unitMat[unitTeam];
    }
}
