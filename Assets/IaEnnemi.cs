using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnnemi : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float distance = 2f;
    private bool movingRight = true;
    public Transform groundDetection;
    public Transform target;
    [SerializeField] public int depart;
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
        if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    
    /*if (transform.position.y < 1)
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
    transform.Translate(Vector2.right * speed * Time.deltaTime);


    /*if(Input.GetButtonDown("R"))
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }*/
    
    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }




}
