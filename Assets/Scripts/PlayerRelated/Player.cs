using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [HideInInspector] public SwitchGravity switchG;
    [HideInInspector] public Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    ControllerCheck controlC;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    
    Vector2 ref_velocity = Vector2.zero;
    float horizontal_value;
    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [SerializeField] float maxFallSpeed;
    //[Range(0, 1)][SerializeField] float smooth_time = 0.5f;

    #region JUMP
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    //float jumpForce = 12f;
    [SerializeField] float jumpingPower = 16f;
    //[SerializeField] bool is_jumping = false;
    [SerializeField] bool can_jump = false;

//bool jump;
    bool doubleJump;
    #endregion



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        controlC = GetComponent<ControllerCheck>(); 
        switchG = GetComponent<SwitchGravity>();
           
        
    }


    void Update()
    {
       #region RUN
        horizontal_value = Input.GetAxis("Horizontal");

        if(horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;
        
        animController.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        #endregion

        //if (moveSpeed_horizontal < 0) moveSpeed_horizontal = 0;
        //var dir = transform.position - hit.transform.position;
        //transform.position += dir.normalized * movemagnitude;

        if( IsGrounded() )
        {
            coyoteTimeCounter = coyoteTime;

        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if(IsGrounded() && !Input.GetButton(controlC.inputJump))
        {
            doubleJump = false;
        }

        // JUMP gravitée positive
        if(rb.gravityScale > 0)
        {
            if (Input.GetButtonDown(controlC.inputJump))
            {
                animController.SetBool("Jumping", true);
                if (coyoteTimeCounter > 0f || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                    doubleJump = !doubleJump;
                }
            }
            if (Input.GetButtonUp(controlC.inputJump) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                coyoteTimeCounter = 0f;
            }
        }
        // JUMP gravitée negative
        if (rb.gravityScale < 0)
        {
            if (Input.GetButtonDown(controlC.inputJump))
            {
                animController.SetBool("Jumping", true);
                if (coyoteTimeCounter > 0f || doubleJump)                  
                {
   
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                 
                    doubleJump = !doubleJump;
                }
            }
            if (Input.GetButtonUp(controlC.inputJump) && rb.velocity.y < 0f)
            {  
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * 0.5f);
                coyoteTimeCounter = 0f;
            }
        }


        #region JUMP & FALL animation
       
            // animations JUMP et lorque le player tombe
        if (rb.gravityScale > 0)
            {
            if ( rb.velocity.y > 0.1f)
            {
                animController.SetBool("Jumping", true);

                if(animController.GetBool("Jumping") == true && (Input.GetButtonDown(controlC.inputJump)))
                {
                   animController.SetTrigger("JumpDouble");
                   animController.SetBool("Jumping", false);
                }
            }
            if (rb.velocity.y < -0.1f)
            {
                animController.SetBool("Jumping", false);
                animController.SetBool("Fall", true);

            }
        }
        if (rb.gravityScale < 0)
        {
            if (!can_jump && rb.velocity.y < -0.1f)
            {
                animController.SetBool("Jumping", true);
                //jump = true;
                if (animController.GetBool("Jumping") == true && (Input.GetButtonDown(controlC.inputJump)))
                {
                    animController.SetTrigger("JumpDouble");
                    animController.SetBool("Jumping", false);
                }
            }
            if (rb.velocity.y > 0.1f)
            {
                //jump = false;
                animController.SetBool("Jumping", false);
                animController.SetBool("Fall", true);

            }
        }
        

    }

    //Correction animation lorsque piup touche le layer Ground.
     private void OnCollisionEnter2D(Collision2D collision)
     {
        if(collision.gameObject.layer == 3)
        {
            animController.SetBool("Fall", false);
            animController.SetBool("Jumping", false);
        }
     }
    #endregion

    void FixedUpdate()
    {
        #region OLD JUMP

        //if(Input.GetButtonDown("Jump"))
        //{
        //    if(can_jump)
        //    {
        //        is_jumping = false;
        //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //        can_jump = false;
        //    }
        //}
        //if(Input.GetButtonUp("Jump") && rb.velocity.y >0f)
        //{
        //    is_jumping = false;
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //    can_jump = false;
        //}

        //if (is_jumping && can_jump)
        //{
        //    if (rb.gravityScale > 0)
        //    {
        //        is_jumping = false;
        //        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //        can_jump = false;


        //    }
        //    else if (rb.gravityScale < 0)
        //    {
        //        is_jumping = false;
        //        rb.AddForce(new Vector2(0, jumpForce * -1), ForceMode2D.Impulse);
        //        can_jump = false;

        //    }
        //}
#endregion 

        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);

        #region MAXFALLSPEED
        //vitesse maximale à lauqelle le player peut tomber gravité positive et négative
        if (rb.velocity.y > 0 && switchG.SensGravity < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Min(rb.velocity.y, maxFallSpeed * -1));
        }
        if (rb.velocity.y < 0 && switchG.SensGravity > 0)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, maxFallSpeed));
        }
        #endregion


    }

    private bool IsGrounded()// vérifie si le player est au sol
    {
        animController.SetBool("Fall", false);
        animController.SetBool("Jumping", false);
        //if(rb.velocity.x == 0) animController.SetTrigger("GroundTouch");
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

}


