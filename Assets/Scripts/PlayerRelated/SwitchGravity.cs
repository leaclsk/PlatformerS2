using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody2D rb;
    bool top;
    bool facingRight;
    public bool inTheZone = false;
    [SerializeField] public bool gravitySwitch = true;
    [SerializeField] public float SensGravity;
    [SerializeField] float cooldownTime;
    [SerializeField] float nextSwitch;
    [SerializeField] private Image GravityCoolDown;


    void Start()
    {
        gravitySwitch = true;
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // inverser la gravit�.
        if(Time.time > nextSwitch)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && gravitySwitch)
            {
                 rb.gravityScale *= -1;

                 Rotation();
                 Flip();
                 

                GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 225, 25);

                nextSwitch = Time.time + cooldownTime;
            }
    
        }
        if (Time.time > nextSwitch)
        {
            GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }



        SensGravity = rb.gravityScale;
        if(!inTheZone) gravitySwitch = true;
        else if(inTheZone) gravitySwitch = false;
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("GravityUp") || collision.CompareTag("GravityDown"))
        {
            inTheZone = true;
            //GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 225, 25);

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GravityUp") || collision.CompareTag("GravityDown"))
        {
            inTheZone = false;
            //GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            
        }
    }

    /* void OnTriggerStay2D(Collider2D collision)
     { 
         if (collision.CompareTag("GravityUp"))
         {
             gravitySwitch = false;
             rb.gravityScale = -3;
             Flip();
             Rotation();

         }
         if (collision.CompareTag("GravityDown"))
         {
             gravitySwitch = false;
             rb.gravityScale = 3;
             Flip();
             Rotation();

         }
         else { gravitySwitch = true; }

     }*/



    // mettre le player � l'endroit : c�d pas la t�te coll�e au plafond mais � l'envers lorsque la 
    //gravit� est invers�e.
    public void Rotation()
    {
        if(top == false){
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else { 
            transform.eulerAngles = Vector3.zero; 
        }
        top = !top;

    }
    //mettre le player � l'endroit, dans le sens de la marche
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 inverse = transform.localScale;
        inverse.x *= -1;
        transform.localScale = inverse;
        //SensGravity = rb.gravityScale;
    }

  
}