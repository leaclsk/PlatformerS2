using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public  int depart;
    [SerializeField] Transform[] points;
    int i;
    [SerializeField] bool moving;


    void Start()
    {
        if(moving)
        {
            transform.position = points[depart].position;
        }
           
    
    }

    void Update()
    {
        if (moving)
        {

        
            if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
            {
                i++;

                if ( i == points.Length)
                {
                    i = 0;
                }
            }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(moving);
            moving = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
