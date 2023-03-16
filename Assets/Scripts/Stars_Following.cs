using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Stars_Following : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]float speed;
    float distance;
    [SerializeField]bool following = false;
    [SerializeField] public int starHealth =0;
    BoxCollider2D bc;


    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //distanceStar = Vector2.Distance(transform.position, Star.transform.position);
        if (following )
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            FollowingStar();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && starHealth <=3)
        {
            
            following = true;
            starHealth++;
            bc.enabled = false;

        }
        
        
    }

    void FollowingStar ()
    { 
        if (distance > 1)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed* Time.deltaTime);
        }
    }
}

