using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] protected int buildingHP;
    [SerializeField] protected int buildingMaxHP;
    [SerializeField] protected int buildingTeam;
    [SerializeField] protected Material[] buildingMat;

    public int Hp { get => buildingHP; set => buildingHP = value; }
    public int MaxHP { get => buildingMaxHP; }
    public int Team { get => buildingTeam; }

    protected Image health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = (float)this.buildingHP / buildingMaxHP;

        if (Death() == true)
        {
            GameObject.Destroy(gameObject);
        }
    }

    protected bool Death()
    {
        bool isDead = false;

        if (this.Hp <= 0)
        {
            isDead = true;
        }

        return isDead;
    }
}
