using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    // Start is called before the first frame update
    void Start()
    {
        buildingHP = 1000;
        buildingMaxHP = buildingHP;
        buildingTeam = Random.Range(0, 2);
        GetComponent<MeshRenderer>().material = buildingMat[buildingTeam];
        switch (buildingTeam)
        {
            case 0:
                gameObject.tag = "BuildingTeam 1";
                break;
            case 1:
                gameObject.tag = "BuildingTeam 2";
                break;
        }
    }
}
