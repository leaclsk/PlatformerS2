using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public  int depart;
    [SerializeField] Transform[] points;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[depart].position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position, points[i].position) < 0.2f)
        {
            i++;
            if ( i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
