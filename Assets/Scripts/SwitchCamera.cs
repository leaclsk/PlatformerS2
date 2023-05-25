using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool CamTuto;
    [SerializeField] bool Cam2;
    [SerializeField] bool Cam3;
    [SerializeField] bool Cam4;
    [SerializeField] bool Cam5;
    [SerializeField] bool Cam6;
    [SerializeField] bool CamBoss1;
    [SerializeField] bool Cam8;
    [SerializeField] bool Cam9;
    [SerializeField] bool fangenMoment;

    [SerializeField] Animator animatorFangen;
    [SerializeField] PlayerHealth playerhealth;

    private void Start()
    {
        playerhealth = GameObject.Find("Piup").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (playerhealth.dead == true && fangenMoment)
        {
       
                animatorFangen.SetBool("CamFangen", false);

        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CamTuto)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("CamTuto", true);
            }
        }
        if (Cam2)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Camera2", true);
            }
        }
        if (Cam3)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Camera3", true);
            }
        }
        if (Cam4)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Camera4", true);
            }
        }
        if (Cam5)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Camera5", true);
            }
        }
        if (Cam6)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Camera6", true);
            }
        }
        if (CamBoss1)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("CamBoss1", true);
            }
        }
        if (Cam8)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Cam8", true);
            }
        }
        if (Cam9)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Cam9", true);
            }
        }

        if(fangenMoment)
        {
            animatorFangen = GameObject.Find("CM vcam Boss 1").GetComponent<Animator>();
            animatorFangen.SetBool("CamFangen", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (CamTuto) animator.SetBool("CamTuto", false);
            if (Cam2) animator.SetBool("Camera2", false);
            if (Cam3) animator.SetBool("Camera3", false);
            if (Cam4) animator.SetBool("Camera4", false);
            if (Cam5) animator.SetBool("Camera5", false);
            if (Cam6) animator.SetBool("Camera6", false);
            if (CamBoss1) animator.SetBool("CamBoss1", false);
            if (Cam8) animator.SetBool("Cam8", false);
            if (Cam9) animator.SetBool("Cam9", false);
        }
        
    }
}
