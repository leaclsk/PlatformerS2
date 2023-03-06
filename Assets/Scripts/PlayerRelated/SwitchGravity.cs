using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody2D rb;
    bool top;
    bool facingRight;
    [SerializeField] bool gravitySwitch = true;

    // Start is called before the first frame update
    void Start()
    {
        gravitySwitch = true;
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // inverser la gravité.
        if(gravitySwitch)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rb.gravityScale *= -1;
                Rotation();
                Flip();
            }
            
        }

       
    }


    void OnTriggerStay2D(Collider2D collision)
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
        
    }
   


    // mettre le player à l'endroit : càd pas la tête collée au plafond mais à l'envers lorsque la 
    //gravité est inversée.
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
    }
}