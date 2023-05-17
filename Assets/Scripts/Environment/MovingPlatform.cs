using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Plateforme qui bouge entre X points.
    [SerializeField] public float speed = 2;
    [SerializeField] public  int depart;
    [SerializeField] Transform[] points;
    int i;
    //Rend les plateformes + modulaires pour le LD
    [SerializeField] bool moving; //choisir si elles bougent de base ou si elle bouge dès que le player saute dessus
    [SerializeField] bool NotLeading; // Utilisé seulement pour qu'elle ne soit plus mouvante et utiliser seulement le parentage.

    [SerializeField] bool isPiston; //rajoute les particles si il s'agit de l'ennemi piston.

    [SerializeField] ParticleSystem ps;

    void Start()
    {

        if (moving)
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

        if (isPiston)
        {  
            if (moving)
            {
                ps.Play();

            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

        if(!NotLeading)
        { 
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(moving);
            moving = true;
        }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
