using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicHealth : MonoBehaviour
{
    [SerializeField] PlayerHealth playerH;
    [SerializeField] float speed;

    Vector3 refVelocity = Vector3.zero;
    


    [SerializeField] Transform playerPosition;
    //[SerializeField] bool followingS = true;

    GameObject[] positionetoile = new GameObject[6];
    int i = -1;
    int step = -1;

    int direction = 0;


   
    private void Start()
    {
        positionetoile[0] = new GameObject();
        positionetoile[1] = new GameObject();
        positionetoile[2] = new GameObject();
        positionetoile[3] = new GameObject();
        positionetoile[4] = new GameObject();
        positionetoile[5] = new GameObject();
    }


    private void Update()
    {
        direction = gameObject.GetComponent<SpriteRenderer>().flipX ? 1 : -1 ;
        for (int j = 0; j < positionetoile.Length; j++)
        {

            if (j == 0)
            {
                positionetoile[j].transform.position = new Vector2(Mathf.Lerp(positionetoile[j].transform.position.x, transform.position.x - step*direction, speed * Time.deltaTime), Mathf.Lerp(positionetoile[j].transform.position.y, transform.position.y, speed * Time.deltaTime));
            }
            else
            {
                positionetoile[j].transform.position = new Vector2(Mathf.Lerp(positionetoile[j].transform.position.x, positionetoile[j-1].transform.position.x - step*direction, speed * Time.deltaTime), Mathf.Lerp(positionetoile[j].transform.position.y, positionetoile[j-1].transform.position.y, speed * Time.deltaTime));
            }

        }
        step = -1;

        //showtab();

        /*for( int j = 0 ; j < positionetoile.Length ; j++)
        {
            
            Vector2 direction = gameObject.transform.position - transform.position;
            positionetoile[j].transform.position = Vector2.MoveTowards(positionetoile[j].transform.position, new Vector2(gameObject.transform.position.x - step, gameObject.transform.position.y + 2), speed * Time.deltaTime);
            step += 1;

            //positionetoile[j].transform.position = new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y);

        }
        step = -1;
        */

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FollowingStar") && playerH.Life < 3)
        {
            i++;
            positionetoile[i] = collision.gameObject;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            playerH.Life++;




        }


    }

    void showtab ()
    {
        for (int i = 0; i < positionetoile.Length; i++)
        {
            Debug.Log("ETOILE " + i + " " + positionetoile[i].transform.position);
        }
    }


}