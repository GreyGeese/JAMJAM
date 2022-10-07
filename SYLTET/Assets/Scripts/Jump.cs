using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1,30)]
    public float JumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    [SerializeField] float groundCheckDistance = 0.04f;
    [SerializeField] LayerMask collisionMask;
    Rigidbody rb;
    BoxCollider collid;

    void Awake()
    {
        collid = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        JumpInput();
    }
    // Update is called once per frame
    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Source: https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=514s

            if (Grounded())
            {
                Debug.Log("i work");

                rb.velocity = Vector3.up * JumpVelocity;
            }
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


    bool Grounded()
    {
        /*RaycastHit2D hit = Physics2D.BoxCast(transform.position, collid.size, 0.0f, Vector2.down, groundCheckDistance, collisionMask);
        if (hit.collider != null) { return true; }
        else return false;*/

        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(transform.lossyScale.x * GetComponent<BoxCollider>().size.x / 2,
           transform.lossyScale.y * GetComponent<BoxCollider>().size.y / 2 + groundCheckDistance), Vector3.right, transform.lossyScale.x * GetComponent<BoxCollider>().size.x, collisionMask);
        
        Debug.DrawRay(transform.position - new Vector3(transform.lossyScale.x * GetComponent<BoxCollider>().size.x / 2,
           transform.lossyScale.y * GetComponent<BoxCollider>().size.y / 2 + groundCheckDistance), Vector3.right * 
           transform.lossyScale.x * GetComponent<BoxCollider>().size.x, Color.red);
        
        if (hit.collider != null && rb.velocity.y <= 0) 
        {
            Component[] temp = hit.collider.gameObject.GetComponents(typeof(JumpableObjectScript));
            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i] as JumpableObjectScript).enabled)
                {
                    (temp[i] as JumpableObjectScript).jumpedOn(gameObject);
                }
            }
            if (rb.velocity.y <= 0) return true; //Behövs för att .jumpedOn kan leda till att spelaren skjuts uppåt
        }
        return false;
    }
}
