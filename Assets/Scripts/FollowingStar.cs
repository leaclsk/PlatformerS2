using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingStar : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    public Transform target;
    float distance;
    bool Following = false;
    int a = 1;
    

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
        if (Following)
        {
            FollowStar();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        { 
        Following = true;
        }
    }

    void FollowStar()
    {
        if (distance > a)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
