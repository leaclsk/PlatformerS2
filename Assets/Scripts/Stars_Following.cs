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
    [SerializeField] public bool following = false;
    [SerializeField] public int starHealth =0;
    BoxCollider2D bc;


    [SerializeField] HealthStar healthStar;



    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (following)
        {
            //distance = Vector2.Distance(transform.position, player.transform.position);
            FollowingStar();
            
        }
    }


    void FollowingStar ()
    {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance > 1)
            {
                Vector2 direction = player.transform.position - transform.position;
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
    }
}

