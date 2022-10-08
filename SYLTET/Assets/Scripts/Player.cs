using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int hearts = 1;
    [Header("weapon")]
    private Weapon weapon;
    Health health;
    private void Start()
    {
        health = new Health(hearts, gameObject);
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        if(weapon != null)Shoot();
    }
    
    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            weapon.timer = 1;
        }
    }
    public void Death()
    {
        health.Death();
    }
}
