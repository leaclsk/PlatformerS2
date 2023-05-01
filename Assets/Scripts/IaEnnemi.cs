using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class IaEnnemi : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public int depart;
    [SerializeField] Transform[] points;
    int i;
    Rigidbody2D rb;

    //private bool directionRight = true;
    //public float speed = 2.0f;
    //[SerializeField] float distance = 4.0f;
    


    void Start()
    {
  
        transform.position = points[depart].position;
        //sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        


        if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
        {
            Vector3 inverse = transform.localScale;
            inverse.x *= -1;
            transform.localScale = inverse;
            i++;
            if (i == points.Length)
            {
                i = 0; // reset l'index

                //flip le blob
                
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);


        //if (directionRight)
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //else
        //    transform.Translate(-Vector2.right * speed * Time.deltaTime);

        //if (transform.position.x >= distance)
        //{
        //    directionRight = false;
        //    gameObject.GetComponent<SpriteRenderer>().flipX = true;
        //}

        //if (transform.position.x <= -distance)
        //{
        //    directionRight = true;
        //    gameObject.GetComponent<SpriteRenderer>().flipX = false;
        //}
    }



    

    
}
