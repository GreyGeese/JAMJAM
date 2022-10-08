using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [Range(1,30)]
    public float JumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    [SerializeField] LayerMask collisionMask;
    Rigidbody rb;
    [SerializeField] BoxCollider collid;
    [SerializeField] private IsGrounded isa;
    bool grounded = true;
    PlayerController pc;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

   
   
    // Update is called once per frame
    public void JumpInput(InputAction.CallbackContext context)
    {
        
        if(isa.isGrounded)
        {
            //Source: https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=514s

            rb.AddForce(5,200,0);
            if (rb.velocity.y < 0)
            {
                JumpUp(fallMultiplier);
            }
            else if (rb.velocity.y > 0)
            {
                JumpUp(lowJumpMultiplier);
            }
        }
    }
    void JumpUp(float hight)
    {
        rb.velocity += Vector3.up * Physics2D.gravity.y * (hight - 1) * JumpVelocity * Time.deltaTime;
    }
}
