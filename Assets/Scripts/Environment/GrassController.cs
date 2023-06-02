using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isCredits;

    void Start()
    {
        animator = GetComponent<Animator>();
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            animator.SetTrigger("Grass");
        }
    }

    private void Update()
    {
        if (isCredits)
        {
            animator.SetTrigger("GrassCredits");
        }
    }

  

}
