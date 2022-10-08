using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats
{
    [SerializeField] private int damge = 25;
    [SerializeField] private GameObject target;


    public BulletStats(GameObject target)
    {
        this.target = target;
    }
    public void AttackGameObject()
    {
        switch (target.tag)
        {
            case "Player":
                target.GetComponent<Player>().Death();
                break;
            default: return;
        }
    }
}
