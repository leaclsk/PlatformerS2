using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnd : MonoBehaviour
{
    [SerializeField] Animator fangenAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            fangenAnimator.SetBool("end", true);
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

}
