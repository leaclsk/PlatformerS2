using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_obj : MonoBehaviour
{
    private GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        PickUpCollectible();
    }
    void PickUpCollectible()
    {
        if (playerRef)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerRef = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerRef = null;
    }
}

