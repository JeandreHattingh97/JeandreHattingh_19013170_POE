using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int unitRange;
    [SerializeField] protected int unitHP;
    [SerializeField] protected int unitMaxHP;
    [SerializeField] protected int unitAtk;
    [SerializeField] protected float unitSpeed;
    [SerializeField] protected int unitTeam;
    [SerializeField] protected Material[] unitMat;

    public int Hp { get => unitHP; set => unitHP = value; }
    public int MaxHP { get => unitMaxHP; }
    public int Atk { get => unitAtk; }
    public float Speed { get => unitSpeed; }
    public int Range { get => unitRange; }
    public int Team { get => unitTeam; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInRange(GetClosestUnit()))
        {
            transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, unitSpeed * Time.deltaTime);
        }
    }



    protected bool IsInRange(GameObject enemy)
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) <= unitRange)
            return true;
        else return false;
    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;

        GameObject[] units = null;

        switch (unitTeam)
        {
            case 0:
                units = GameObject.FindGameObjectsWithTag("Team 2");
                break;
            case 1:
                units = GameObject.FindGameObjectsWithTag("Team 1");
                break;
            case 2:
                units = GameObject.FindGameObjectsWithTag("Team 3");
                break;
        }

        float distance = 9999;

        foreach (GameObject temp in units)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        return unit;
    }
}
