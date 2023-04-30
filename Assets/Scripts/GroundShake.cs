using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
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
