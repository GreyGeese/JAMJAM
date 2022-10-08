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
    [SerializeField] Rigidbody rB;
    public int jumpForce;
    public UnityEvent FireEvent;
    public UnityEvent JumpEvent;
    [SerializeField] private float jumpCD = 0.8f;
    private float timer = 1;
    public bool moveLeft = false;
    private AnimationManager animManager;


    [SerializeField] private PlayerAudioManager audioManager;
    [SerializeField] private IsGrounded groundCheck;

    private void OnEnable()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<PlayerAudioManager>();
        animManager = GetComponent<AnimationManager>();
        //rB = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //transform.Translate(new Vector3(moveInp.x, transform.position.y, 0) * speed * Time.deltaTime);



    }
    private void Update()
    {

        if (groundCheck.isGrounded)
        {
            animManager.SetBoolTrue("Grounded");
        }
        else
        {
            animManager.SetBoolFalse("Grounded");
        }

        if (moveInp.x == 0)
        {
            rB.velocity = new Vector3(0, rB.velocity.y, 0);
            animManager.SetBoolTrue("Idle");
            animManager.SetBoolFalse("Run");
        }
        else
        {
            animManager.SetBoolFalse("Idle");
            animManager.SetBoolTrue("Run");
        }

        if(moveInp.x > 0 && moveLeft)
        {
            
            audioManager.playSoundswithKeyCode("weehoo");
            //animManager.SetTrigger("Turn");
            transform.rotation = Quaternion.Euler(0, 90, 0);
            moveLeft = false;
        }
        
        if(moveInp.x < 0 && !moveLeft)
        {
            
            audioManager.playSoundswithKeyCode("weehoo");
            //animManager.SetTrigger("Turn");
            transform.rotation = Quaternion.Euler(0, -90, 0);
            moveLeft = true;
        }
        if (moveInp.x > 0)
        {
            rB.velocity = new Vector3(speed, rB.velocity.y, 0);
        }
        if (moveInp.x < 0)
        {
            rB.velocity = new Vector3(-speed, rB.velocity.y, 0);
        }


        timer += Time.deltaTime;
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInp = ctx.ReadValue<Vector2>();
        Debug.Log(moveInp);
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (groundCheck.isGrounded && timer > jumpCD)
        {
            JumpEvent.Invoke();
            //rB.AddForce(0, 1 * jumpForce, 0);
            Debug.Log("Jump!");
            timer = 0;
        }


    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
        FireEvent.Invoke();
    }

    public Vector2 GetMoveInp()
    {
       return moveInp;
    }

}
