using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody2D rb;
    bool top;
    Player player;
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // inverser la gravit�.
        if(Input.GetKeyDown(KeyCode.E))
        { 
            rb.gravityScale *= -1;
            Rotation();
            Flip();
        }
    }


     // mettre le player � l'endroit : c�d pas la t�te coll�e au plafond mais � l'envers lorsque la 
    //gravit� est invers�e.
    void Rotation()
    {
        if(top == false){
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else { 
            transform.eulerAngles = Vector3.zero; 
        }
        top = !top;

    }
    //mettre le player � l'endroit (qu'il regarde vers la droite lorsqu'il va � droite)
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 inverse = transform.localScale;
        inverse.x *= -1;
        transform.localScale = inverse;
    }
}