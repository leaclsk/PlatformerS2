using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    public SwitchGravity switchG;
    public Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    ControllerCheck controlC;


    
    Vector2 ref_velocity = Vector2.zero;
    float horizontal_value;
    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [SerializeField] float maxFallSpeed;
    //[Range(0, 1)][SerializeField] float smooth_time = 0.5f;

    #region JUMP
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    float jumpForce = 12f;
    [SerializeField] float jumpingPower = 16f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool can_jump = false;

    bool doubleJump;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        controlC = GetComponent<ControllerCheck>();
        
        
        //Debug.Log(Mathf.Lerp(current, target, 0));
       
        
    }

    // Update is called once per frame
    void Update()
    {
        #region RUN
        horizontal_value = Input.GetAxis("Horizontal");

        if(horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;
        
        animController.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        #endregion

        /*if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            animController.SetBool("Jumping", false);
            animController.SetBool("Fall", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                doubleJump = !doubleJump;
            }
        }*/
        if(IsGrounded() && !Input.GetButton(controlC.inputJump))
        {
            doubleJump = false;
           // animController.SetBool("Jumping", false);
           // animController.SetBool("Fall", false);
        }
        if(rb.gravityScale > 0)
        {
            if (Input.GetButtonDown(controlC.inputJump))
            {
                if (IsGrounded() || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                    doubleJump = !doubleJump;
                }
            }
            if (Input.GetButtonUp(controlC.inputJump) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
        if (rb.gravityScale < 0)
        {
            if (Input.GetButtonDown(controlC.inputJump))
            {
                if (IsGrounded() || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);

                    doubleJump = !doubleJump;
                }
            }
            if (Input.GetButtonUp(controlC.inputJump) && rb.velocity.y < 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * 0.5f);
            }
        }






        //if (Input.GetButtonDown("Jump") || doublejump)
        //{
        //    if(can_jump)
        //    {
        //        if (rb.gravityScale > 0)
        //        {

        //            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //            can_jump = false;
        //            doublejump = !doublejump;


        //        }
        //        else if (rb.gravityScale < 0)
        //        {

        //            rb.AddForce(new Vector2(0, jumpForce * -1), ForceMode2D.Impulse);
        //            can_jump = false;
        //            doublejump = !doublejump;

        //        }
        //    }


        //}

        //if (is_jumping && can_jump)
        //{

        //}
        #region JUMP & FALL animation

        if (rb.gravityScale > 0)
        {
            if ( rb.velocity.y > 0.1f)
            {
                animController.SetBool("Jumping", true);
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
            }
            if (rb.velocity.y > 0.1f)
            {
                animController.SetBool("Jumping", false);
                animController.SetBool("Fall", true);

            }
        }
        #endregion

    }
    void FixedUpdate()
    {
        
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


        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);

        #region MAXFALLSPEED
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
   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            can_jump = true;
            doubleJump = false;
            
            animController.SetBool("Jumping", false);
            animController.SetBool("Fall", false);
        }
        

    }*/

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    can_jump = false;
    //    doubleJump = false;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            rb.velocity = new Vector2(rb.velocity.x*-15f, rb.velocity.y*4f);
        }
    }
    private bool IsGrounded()
    {
        animController.SetBool("Fall", false);
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

}


