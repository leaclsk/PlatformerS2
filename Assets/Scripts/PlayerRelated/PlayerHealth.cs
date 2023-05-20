using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Initialisation et hidden
    SwitchGravity switchG;
    OrganicHealth organicHealth;
    ControllerCheck controlC;

    Rigidbody2D rb;
    Animator animController;
    SpriteRenderer sr;
  
    Vector2 ref_velocity = Vector2.zero;
    [HideInInspector] public Vector3 PosRespawn = Vector3.zero;
    [HideInInspector] public bool Respawn = false;
    [HideInInspector] public bool dead = false;
    #endregion

    [Header("Life And Damage")]
    public int Life = 0;
    [SerializeField] float cooldownTime;
    [SerializeField] float timeInRed;
    float nextdamage;
    bool damaged;
    float timer;

    [SerializeField] bool BlackHole = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        organicHealth = GetComponent<OrganicHealth>();
        sr = GetComponent<SpriteRenderer>();
        PosRespawn = this.transform.position;
        controlC = GetComponent<ControllerCheck>();
        switchG = GetComponent<SwitchGravity>();
        timer = timeInRed;
    }

    private void Update()
    {
        #region timerInREd
        if (timer > 0 && damaged)
        {
            sr.color = new Color(1, 0.6f, 0.6f);
            timer -= Time.deltaTime;
        }

        if (timer < 0) timer = 0;
        if (timer == 0)
        {
            sr.color = Color.white;
            damaged = false;
            timer = timeInRed;
        }
        #endregion

        if (Life < 0)
        {
            Death();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Time.time > nextdamage)
        {

            if (collision.gameObject.tag == "DamageZone" && Life > -1)
            {
                TakeDamage(1);
                damaged = true;
                nextdamage = Time.time + cooldownTime;
            }
            if (collision.gameObject.tag == "DriftZone")
            {
                TakeDamage(4);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("DriftZone"))
        //{
        //    TakeDamage(4);
        //}

        if (other.CompareTag("BlackHole"))
        {
                BlackHole = true;
                animController.SetBool("BlackH", true);
                TakeDamage(1);
        }
       

        }


    #region VOID
    public void TakeDamage(int damage)
    {
       Life -= damage;

        if (organicHealth.positionetoile[organicHealth.i] != null)
        {
            
            Destroy(organicHealth.positionetoile[organicHealth.i]);
            organicHealth.positionetoile[organicHealth.i] = new GameObject();
            
            organicHealth.i--;
        }
        //Destroy(organicHealth.positionetoile[organicHealth.i]);
        //organicHealth.positionetoile[organicHealth.i] = Destroy(gameObject);
        //organicHealth.i--;
    }

    public void Death()
    {  
        rb.velocity = new Vector2(rb.velocity.x * -25f, rb.velocity.y * 6f);  
        dead = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if(!BlackHole)animController.SetBool("isDead", true);
        
        if (Input.GetButtonDown(controlC.inputJump))
        {

            Respawn = true;
            gameObject.transform.position = PosRespawn;
            //healthBar.SetMaxHealth(maxHealth);

            if (switchG.SensGravity < 0)
            {
                rb.gravityScale = 3;
                switchG.Rotation();
                switchG.Flip();
            }

            Life = 1;
            //currentHealth = 100; On reset la vie
            animController.SetBool("isDead", false);
            animController.SetBool("BlackH", false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Respawn = false;
            dead = false;
        }
    }
    public void SetPosRespawn(Vector3 Position)
    {      
        this.transform.position = PosRespawn;
    }
    #endregion

}
