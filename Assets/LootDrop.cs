using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    private Vector3 velocity = Vector3.up;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    StarCoin starCoin;

    //int force = 6;
    


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        //rb.useGravity = false;

        startPosition = this.transform.position;
        //velocity *= Random.Range(4f, 6f);
        //velocity += new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 0);

        //velocity.y = (Random.Range(1f, 3f));
        //velocity.x = (Random.Range(1f, 3f));
        


    }

   
    void Update()
    {

        velocity -= new Vector3((Random.Range(-1f, 3f)), (Random.Range(1f, 3f)), 0) * 5 * Time.deltaTime;
       


        //velocity = new Vector2(Mathf.Lerp(this.transform.position.x, this.transform.position.y, Time.deltaTime), Mathf.Lerp((Random.Range(-1f, 2f)), (Random.Range(3f, 5f)), Time.deltaTime)) ;
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Time.deltaTime);
        //rb.velocity = new Vector2(rb.velocity.x * Random.Range(-4f, 6f), rb.velocity.y * Random.Range(4f, 6f));

        //rb.AddForce(new Vector3(0, 1, 0) * force, ForceMode2D.Impulse);

        if (Mathf.Abs(rb.position.y - startPosition.y) < 0.25f && velocity.y < 0f)
                {

                //rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = velocity;
                this.enabled = false;
          
                }

            
            
        
       
    }
}
