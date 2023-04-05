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
        // inverser la gravité avec cooldown.
        if(Time.time > nextSwitch)
        {
            GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            if (Input.GetKeyDown(KeyCode.E) && gravitySwitch)
            {
                 rb.gravityScale *= -1;

                 Rotation();
                 Flip();

                 GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 225, 25);

                 nextSwitch = Time.time + cooldownTime;
            }
    
        }

        SensGravity = rb.gravityScale;
        if(!inTheZone) gravitySwitch = true;
        else if(inTheZone) gravitySwitch = false;

        //cooldown UI grise 
        if(!gravitySwitch) GravityCoolDown.GetComponent<Image>().color = new Color32(255, 255, 225, 25);
        
    }

    //zones de gravité forcée
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


    // mettre le player à l'endroit 
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
    //mettre le player à l'endroit, dans le sens de la marche
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 inverse = transform.localScale;
        inverse.x *= -1;
        transform.localScale = inverse;
        //SensGravity = rb.gravityScale;
    }

  
}