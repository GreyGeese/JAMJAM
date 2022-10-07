using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Weapon weapon;
    private void Start()
    {
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        Shoot();
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
}
