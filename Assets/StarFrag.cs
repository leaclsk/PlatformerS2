using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFrag : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Animator lightAnimator;



    private void Start()
    {
        //ps.Pause();
    }
    private void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //ps.Play();
            animator.SetBool("Collected", true);
            //lightAnimator.SetBool("Collected", true);
        }
    }



}
