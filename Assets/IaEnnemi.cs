using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Tilemaps;
using UnityEngine;

public class IaEnnemi : MonoBehaviour
{
    //[SerializeField] public float speed = 2;
    //[SerializeField] public int depart;
    //[SerializeField] Transform[] points;
    //int i;
    // int direction = 0;

    private bool directionRight = true;
    public float speed = 2.0f;
    [SerializeField] float distance = 4.0f;


    void Update()
    {
        if (directionRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= distance)
        {
            directionRight = false;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (transform.position.x <= -distance)
        {
            directionRight = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }



    void Start()
    {
        // transform.position = points[depart].position;
        // sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    //void Update()
    // {
    //direction = gameObject.GetComponent<SpriteRenderer>().flipX ? 1 : -1;


    // if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
    //  {
    //    i++;
    //   if ( i == points.Length)
    //    {
    //   i = 0;          
    //Vector3 inverse = transform.localScale;
    //inverse.x *= -1;
    //transform.localScale = inverse;
    //gameObject.transform.localScale = new Vector3(-1, 1, 1);
    //       gameObject.GetComponent<SpriteRenderer>().flipX = true;
    //     }
    //   }

    //     transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    // }
}
