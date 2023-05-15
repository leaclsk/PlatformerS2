using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    //mouvement de plateforme quand le player saute dessus : rebondit légèrement.
    //bool activ = true;
    [SerializeField]float movement = 0.25f;
    [SerializeField] Player player;
    Vector2 posPlatform;

    private void Start()
    {
        player = GameObject.Find("Piup").GetComponent<Player>();
        posPlatform = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            transform.Translate(0, -movement*(Mathf.Abs(player.rb.gravityScale)/ player.rb.gravityScale),0);
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        transform.position = posPlatform;

    }
}
