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

    private int maxHealth = 100;
    public int currentHealth = 0;
    Vector2 ref_velocity = Vector2.zero;
    public Vector3 PosRespawn = Vector3.zero;
    public bool Respawn = false;

    
    [SerializeField] Health healthBar;

    [SerializeField] Stars_Following starFollowing;
    


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController= GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        SetPosRespawn(PosRespawn);
    }

    private void Update()
    {
        Debug.Log(starFollowing.starHealth);
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(20);

        }
        //if (currentHealth <= 0)
       // {
       //     Death();
        //}
        if (starFollowing.starHealth < 0)
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sprikes"))
        {
           
            TakeDamage(3);
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DamageZone"))
        {
           
                    StartCoroutine(Damage());
               
        }         

    }

IEnumerator Damage()
{
        TakeDamage(1);
        yield return new WaitForSeconds(20f);
    
}

private void TakeDamage(int damage)
    {
        //currentHealth -= damage;
        starFollowing.starHealth-= damage;
        //healthBar.SetHealth(currentHealth);
        starFollowing.starHealth--;
    }

    public void Death()
    {
        
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animController.SetBool("isDead", true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Respawn = true;
            gameObject.transform.position = PosRespawn;
            healthBar.SetMaxHealth(maxHealth);
            
           
            
            if(switchG.SensGravity < 0)
            {
                rb.gravityScale = 3;
                switchG.Rotation();
                switchG.Flip();
            }

            
            currentHealth = 100;
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
