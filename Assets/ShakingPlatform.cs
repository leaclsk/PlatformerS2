using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingPlatform : MonoBehaviour
{
    //mouvement de plateforme quand le player saute dessus : rebondit l�g�rement.
    Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("JumpedOn");
        }
    }
}
