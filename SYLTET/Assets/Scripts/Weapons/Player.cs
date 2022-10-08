using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] private float acceleration = 60;
    [SerializeField] private float deceleration = 60;
    [SerializeField] private float maxSpeed = 10;
    [Header("Health")]
    [SerializeField] private int hearts = 1;
    [Header("weapon")]
    private Weapon weapon;
    private MovementSats movement;
    private Vector2 input;
    [Header("Spawner")]
    [SerializeField] private Spawner spawner;
    Health health;
    private void Start()
    {
        health = new Health(hearts, gameObject);
        movement = new MovementSats(acceleration, deceleration, maxSpeed, transform);
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(input.x, transform.position.y, 0) * Time.deltaTime);
        if (weapon != null)Shoot();
    }
    public void Controllers(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        Debug.Log(input);
        //Vector2 input = Vector2.right * Input.GetAxisRaw("Horizontal");
        if (input.x > 0) transform.rotation = new Quaternion(0, 180, 0, 0); if(input.x < 0) transform.rotation = new Quaternion(0, 0, 0, 0);
        //movement.Movement(input);
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
        spawner.setStartRespawn(gameObject);
        health.Death();
    }
}
