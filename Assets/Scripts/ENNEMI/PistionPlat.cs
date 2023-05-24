using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistionPlat : MonoBehaviour
{
    [SerializeField] float movement = 1f;
    [SerializeField] float cooldownTime;
    [SerializeField] float nextPuch;
    bool puchside = true;

    private Vector2 target;
    private Vector2 retourtarget;
    private Vector2 position;
    [SerializeField] private float speed = 10.0f;

    private void Start()
    {
        position = gameObject.transform.position;
        target = new Vector2(position.x , position.y + movement);
        retourtarget = new Vector2(position.x, target.y - movement);
    }
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        if (puchside) // montée
        {
            if (Time.time > nextPuch)
            {
                // transform.position = Vector2.MoveTowards(transform.position, target, step);
                transform.position = Vector2.Lerp(position, target, 2);
                //transform.Translate(0, movement, 0);
                nextPuch = Time.time + cooldownTime;
                puchside = !puchside;
            }
            
            
        }
        /*if (!puchside) // descente
        {
            if (Time.time > nextPuch)
            {
                transform.position = Vector2.Lerp(target, position, 2);
                // transform.position = Vector2.MoveTowards(transform.position, retourtarget, step);
                //transform.Translate(0, -movement, 0);
                nextPuch = Time.time + cooldownTime;
                puchside = !puchside;
            }
        }*/


    }

}
