using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    //mouvement de plateforme quand le player saute dessus : rebondit légèrement.
    //bool activ = true;
    [SerializeField]float movement = 0.25f;
    [SerializeField] Player player;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.rb.gravityScale > 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.transform.SetParent(transform);
                transform.Translate(0, -movement, 0);

            }
        }
        //modifier le mouvement en fonction du sens dans lequel le player saute sur la plateforme.
        if (player.rb.gravityScale < 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.transform.SetParent(transform);
                transform.Translate(0, movement, 0);
                
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        if (player.rb.gravityScale > 0)
        { transform.Translate(0, movement, 0); }
        else { transform.Translate(0, -movement, 0); }
    }
}
