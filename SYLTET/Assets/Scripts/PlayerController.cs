using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Vector2 moveInp;
    private int jump = 0;
    private Rigidbody rB;
    public int jumpForce;
    public UnityEvent FireEvent;
    public UnityEvent JumpEvent;
    [SerializeField] private float jumpCD = 0.8f;
    private float timer = 1;
    private bool moveLeft = true;
    
    [SerializeField] private IsGrounded groundCheck;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveInp.x, transform.position.y, 0) * speed * Time.deltaTime);
        


    }
    private void Update()
    {
        if (moveInp.x > 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
        if (moveLeft)
        {
            transform.Rotate(0, 0, 0);
        }
        else
        {
            transform.Rotate(0, 180, 0);
        }
        timer += Time.deltaTime;
    }
    public void OnMove(InputAction.CallbackContext ctx) => moveInp = ctx.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if (groundCheck.isGrounded && timer > jumpCD)
        {
            rB = gameObject.GetComponent<Rigidbody>();
            rB.AddForce(0, 1 * jumpForce, 0);
            Debug.Log("Jump!");
            JumpEvent.Invoke();
            timer = 0;
        }
       
       
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
        FireEvent.Invoke();
    }

   

}
