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

    protected Image health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyUnits01 = null;
        GameObject[] enemyUnits02 = null;

        if (gameObject.tag != "Team 3")
        {
            if (!Death())
            {
                if(this.Hp >= (0.25 * MaxHP))
                {
                    GameObject closestUnit = GetClosestUnit();

                    if (!IsInRange(GetClosestUnit()))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, unitSpeed * Time.deltaTime);
                    }
                    else
                    {
                        Attacking(closestUnit);
                    }
                }
                else
                {
                    GameObject runAway = new GameObject();
                    runAway.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                    transform.position = Vector3.MoveTowards(transform.position, runAway.transform.position, Speed * Time.deltaTime);
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Team 3")
        {
            if (!Death())
            {
                if (this.Hp >= (0.25 * MaxHP))
                {
                    GameObject closestUNnit = GetClosestUnit();

                    if (!IsInRange(GetClosestUnit()))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, unitSpeed * Time.deltaTime);
                    }
                    else
                    {
                        enemyUnits01 = GameObject.FindGameObjectsWithTag("Team 1");
                        enemyUnits02 = GameObject.FindGameObjectsWithTag("Team 2");
                        foreach (GameObject temp in enemyUnits01)
                        {
                            if (!temp.name.Contains("Building"))
                            {
                                if (IsInRange(temp))
                                {
                                    Attacking(temp);
                                }
                            }
                        }

                        foreach (GameObject temp in enemyUnits02)
                        {
                            if (!temp.name.Contains("Building"))
                            {
                                if (IsInRange(temp))
                                {
                                    Attacking(temp);
                                }
                            }
                        }
                    }
                }
                else
                {
                    GameObject runAway = new GameObject();
                    runAway.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                    transform.position = Vector3.MoveTowards(transform.position, runAway.transform.position, Speed * Time.deltaTime);
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }

        health.fillAmount = (float)this.Hp / MaxHP;

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

        GameObject[] units01 = null;
        GameObject[] units02 = null;
        GameObject[] buildings = null;

        switch (unitTeam)
        {
            case 0:
                units01 = GameObject.FindGameObjectsWithTag("Team 2");
                units02 = GameObject.FindGameObjectsWithTag("Team 3");
                buildings = GameObject.FindGameObjectsWithTag("BuildingTeam 2");
                break;
            case 1:
                units01 = GameObject.FindGameObjectsWithTag("Team 1");
                units02 = GameObject.FindGameObjectsWithTag("Team 3");
                buildings = GameObject.FindGameObjectsWithTag("BuildingTeam 1");
                break;
            case 2:
                units01 = GameObject.FindGameObjectsWithTag("Team 1");
                units02 = GameObject.FindGameObjectsWithTag("Team 2");
                buildings = GameObject.FindGameObjectsWithTag("Ground");
                break;
        }

        float distance = 9999;

        foreach (GameObject temp in units01)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        foreach (GameObject temp in units02)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        foreach (GameObject temp in buildings)
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

    protected void Attacking(GameObject enemy)
    {
        if (enemy.name.Contains("Unit"))
        {
            enemy.GetComponent<Unit>().Hp -= this.Atk;
        }
        else if (enemy.name.Contains("Building"))
        {
            enemy.GetComponent<Building>().Hp -= this.Atk;
        }

    }

    protected bool Death()
    {
        bool isDead = false;

        if(this.Hp <= 0)
        {
            isDead = true;
        }

        return isDead;
    }
}
