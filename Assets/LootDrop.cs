using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    private Vector3 velocity = Vector3.up;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    StarCoin starCoin;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        //rb.useGravity = false;

        startPosition = this.transform.position;
        //velocity *= Random.Range(4f, 6f);
        //velocity += new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 0);

    }

   
    void Update()
    {

        
                /*if (velocity.y < -4f)
                {
                velocity.y = -4f;
                }*/
             
                
                velocity -= Vector3.up * 5 * Time.deltaTime;
                //velocity = new Vector2(rb.velocity.x * Random.Range(-4f, 6f), rb.velocity.y * Random.Range(4f, 6f));
        

                if (Mathf.Abs(rb.position.y - startPosition.y) < 0.25f && velocity.y < 0f)
                {

                //rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = velocity;
                this.enabled = false;
          
                }

            
            
        
       
    }
}
