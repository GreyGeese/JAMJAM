using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
          
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
    
}
