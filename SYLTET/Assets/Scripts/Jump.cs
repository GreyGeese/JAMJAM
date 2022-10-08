using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1,30)]
    public float JumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    [SerializeField] LayerMask collisionMask;
    Rigidbody rb;
    [SerializeField] BoxCollider collid;
    bool grounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, collisionMask);
        if (hitColliders.Length > 0) grounded = true;
        JumpInput();
    }
    // Update is called once per frame
    void JumpInput()
    {

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            //Source: https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=514s

            rb.velocity = Vector3.up * JumpVelocity;
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
