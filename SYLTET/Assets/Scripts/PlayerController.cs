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
    private bool isGrounded;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveInp.x, transform.position.y, 0) * speed * Time.deltaTime);
    }
    public void OnMove(InputAction.CallbackContext ctx) => moveInp = ctx.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rB = gameObject.GetComponent<Rigidbody>();
            rB.velocity = Vector3.zero;
            rB.AddForce(0, 1 * jumpForce, 0);
            Debug.Log("Jump!");
            JumpEvent.Invoke();
        }
       
       
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
        FireEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;  
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = false;
        }
    }

}
