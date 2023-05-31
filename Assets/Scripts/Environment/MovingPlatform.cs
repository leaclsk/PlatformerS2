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
    [SerializeField] ParticleSystem psFront;
    [SerializeField] ParticleSystem psBack;
    Rigidbody2D rb;

    PlayerHealth health;
    ControllerCheck controlc;

    bool chase;
   [SerializeField] Transform pointDepart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GameObject.Find("Piup").GetComponent<PlayerHealth>();
        controlc = GameObject.Find("Piup").GetComponent<ControllerCheck>();
        if (moving)
        {
            transform.position = points[depart].position;
        }


    }

    void Update()
    {
        if (health.Life == -1 && !isPiston)
        {
            moving = false;
            if(Input.GetButtonDown(controlc.inputJump))
            {
                transform.position = points[depart].position;
            }
            
        }


        if (moving)
        {

            if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
            {
                i++;

                if (isPiston)
                {
                    psFront.Play();
                    psBack.Play();
                }

                if ( i == points.Length)
                {
                    i = 0;
                    if (isPiston)
                    {
                        psFront.Stop();
                        psBack.Stop();
                    }

                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

        if(!NotLeading)
        { 
        if(collision.gameObject.tag == "Player")
        {
            
            moving = true;
        }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
