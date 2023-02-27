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
    bool Following = false;
    
    //[SerializeField] GameObject Star;
    //float distanceStar;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        //distanceStar = Vector2.Distance(transform.position, Star.transform.position);
        if (Following)
        {
            FollowingStar();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Following = true;
        
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

