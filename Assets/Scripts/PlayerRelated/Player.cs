using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public SwitchGravity switchG;
    public Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    float horizontal_value;
    Vector2 ref_velocity = Vector2.zero;


    float jumpForce = 12f;

    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool can_jump = false;
    [SerializeField] float maxFallSpeed;
    //[Range(0, 1)][SerializeField] float smooth_time = 0.5f;


    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        
        
        //Debug.Log(Mathf.Lerp(current, target, 0));
       
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");

        if(horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;
        
        animController.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
   
        if (Input.GetButtonDown("Jump") && can_jump)
        {
            is_jumping = true;
            //animController.SetBool("Jumping", true);

            
        }

        if(rb.gravityScale > 0)
        {
            if (!can_jump && rb.velocity.y > 0.1f)
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



    }
    void FixedUpdate()
    {
        if (is_jumping && can_jump)
        {
            if (rb.gravityScale > 0)
            {
                is_jumping = false;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                can_jump = false;

            }
            else if (rb.gravityScale < 0)
            {
                is_jumping = false;
                rb.AddForce(new Vector2(0, jumpForce * -1), ForceMode2D.Impulse);
                can_jump = false;

            }
        }
        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);

        if (rb.velocity.y > 0 && switchG.SensGravity < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Min(rb.velocity.y, maxFallSpeed * -1));
        }
         if (rb.velocity.y < 0 && switchG.SensGravity > 0)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, maxFallSpeed));
        }

        

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        can_jump = true;
        animController.SetBool("Jumping", false);
        animController.SetBool("Fall", false);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        can_jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            //rb.velocity += Vector2.up * 10f;
            rb.velocity = new Vector2(rb.velocity.x*-15f, rb.velocity.y*4f);
        }
    }
    }


