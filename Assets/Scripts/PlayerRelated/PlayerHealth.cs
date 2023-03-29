using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public SwitchGravity switchG;


    //[SerializeField] Health healthBarRef;
    Rigidbody2D rb;
    Animator animController;

    //private int maxHealth = 100;
    //public int currentHealth = 0;
    Vector2 ref_velocity = Vector2.zero;
    public Vector3 PosRespawn = Vector3.zero;
    public bool Respawn = false;

    public bool dead = false;


    public float amount = 0;
    public int Life = 0;







    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        SetPosRespawn(PosRespawn);
    }

    private void Update()
    {
        // Debug.Log(starFollowing.starHealth);
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(1);

        }
        /*if (currentHealth <= 0)
       {
            Death();
        }*/


        if (Life < 0)
        {
            Death();
        }






    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sprikes"))
        {
            TakeDamage(2);
        }
        if (other.CompareTag("DamageZone"))
        {

            TakeDamage(1);

        }
        if (other.CompareTag("Ennemi"))
        {

            TakeDamage(1);

        }
    }


    public void Amount()
    {
        amount += 1;

    }


    private void TakeDamage(int damage)
    {
        //currentHealth -= damage;
        Life -= damage;
        //healthBar.SetHealth(currentHealth);
        

    }

    public void Death()
    {
        dead = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animController.SetBool("isDead", true);
        if (Input.GetKeyDown(KeyCode.Space))
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
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Respawn = false;
            dead = false;

        }
    }
    public void SetPosRespawn(Vector3 Position)
    {
        gameObject.transform.position = PosRespawn;
    }

}
