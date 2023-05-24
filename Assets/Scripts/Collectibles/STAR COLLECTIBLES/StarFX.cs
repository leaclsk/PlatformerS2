using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFX : MonoBehaviour
{
    [SerializeField] ParticleSystem starFx;


    void Start()
    {
        starFx = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
            starFx.Play();


        }
    }
}
