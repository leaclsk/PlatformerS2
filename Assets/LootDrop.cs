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
        startPosition = this.transform.position;
        velocity *= Random.Range(4f, 6f);
        velocity += new Vector3(Random.Range(-1f, 1f), 0, 0);

        rb = this.GetComponent<Rigidbody2D>();
        //rb.useGravity = false;
        rb.isKinematic = true;


    }

   
    void Update()
    {
        if (starCoin.spawnLoot)
        {
            rb.position = velocity * Time.deltaTime;

            if (velocity.y < -4f)
            {
                velocity.y = -4f;
            }
            else
            {
                velocity -= Vector3.up * 5 * Time.deltaTime;
            }

            if (Mathf.Abs(rb.position.y - startPosition.y) < 0.25f && velocity.y < 0f)
            {
                //rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = velocity;
                this.enabled = false;
            }
        }
       
    }
}
