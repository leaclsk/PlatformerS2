using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicHealth : MonoBehaviour
{
    [SerializeField] PlayerHealth playerH;
    [SerializeField] GameObject playerRef;
    Vector3 refVelocity = Vector3.zero;
    [SerializeField] float smoothTime;
    private bool touched = false;
    [SerializeField] private float offset;

    [SerializeField] float speed = 5f;
    float distance;
    float etoileDistance;

    [SerializeField] bool followingS = true;

    
  
    void Update()
    {

        if (touched == true)
        {
            if (followingS)
            {
              FollowingStar(1);
            }
 
        }

        if(playerH.dead)
        {
            followingS = false;
            Destroy(gameObject);
        }
      
    }

    //faire un tableau de 3 cases, quand on récupère 1 étoile elle prend la position de la case 0, l'autre la case 2 etc. on lui donne la distance qu'on veut entre elle et le player et pour chaque étoile suite on multiplie par le nombre d'étoile. 
    // Quand on perd une étoile, la dernière part et la dernière case se vide.

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerH.Life < 3)
        {
            if (!touched)
            {
                
                touched = true;
                playerH.Life += 1;
               
            }
            
            if (playerH.Life == 1)
            {
                FollowingStar(3);
                touched = true;
            }
            /*
                            if (playerH.Life == 3)
                            {

                                FollowingStar(5);
                                touched = true;
                            }*/

        }

        

    }
    

    void FollowingStar(float distanceMax)
    {
  
            distance = Vector2.Distance(transform.position, playerRef.transform.position);

            if (distance > distanceMax)
            {
                Vector2 direction = playerRef.transform.position - transform.position;
                transform.position = Vector2.MoveTowards(this.transform.position, playerRef.transform.position, speed * Time.deltaTime);
            }

    }
}


