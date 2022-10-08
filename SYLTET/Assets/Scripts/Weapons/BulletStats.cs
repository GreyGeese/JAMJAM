using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats
{
    
    [SerializeField] private GameObject target;


    public BulletStats(GameObject target)
    {

        this.target = target;
        
    }
    public void AttackGameObject()
    {
        Debug.Log("trff");
        switch (target.tag)
        {
            case "Player":
                Debug.Log("trff");
                target.GetComponent<Player>().Death();
                target.GetComponent<Player>().IncreaseScore();

                break;
            default: return;
        }
    }
}
