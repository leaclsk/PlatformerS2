using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleZone : MonoBehaviour
{
    [SerializeField] GameObject hidenZone;
    SpriteRenderer sr;

    void Start()
    {
        sr = GameObject.Find("Hidden").GetComponent<SpriteRenderer>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.color = new Color32(255, 255, 255, 10);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            sr.color = new Color32(255, 255, 255, 225); 
        }
    }
}
