using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStar : MonoBehaviour
{
    public SwitchGravity switchG;

    Rigidbody2D rb;
    Animator animController;

    
    public Vector3 PosRespawn = Vector3.zero;
    public bool Respawn = false;

    Stars_Following followingStar;

    
    [SerializeField] public int starHealth = 0;
    BoxCollider2D bc;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        SetPosRespawn(PosRespawn);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(starFollowing.starHealth);
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(20);

        }
        /*if (currentHealth <= 0)
       {
            Death();
        }*/
        if (starHealth < 0)
        {
            Death();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
            if (collision.gameObject.CompareTag("FollowingStar") && starHealth <= 3)
            {
                active = false;
                followingStar.following = true;
                starHealth++;
                //bc.enabled = false;
            }
        if (collision.CompareTag("Sprikes"))
        {
            TakeDamage(3);
        }

    }
    private void TakeDamage(int damage)
    {
        //currentHealth -= damage;
        starHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        starHealth--;
    }

        public void Death()
        {

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

                starHealth = 1;
                //currentHealth = 100;
                animController.SetBool("isDead", false);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Respawn = false;
            }
        }

   

    public void SetPosRespawn(Vector3 Position)
    {
        gameObject.transform.position = PosRespawn;
    }

}
        
 
   


