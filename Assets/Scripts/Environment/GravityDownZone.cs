using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDownZone : MonoBehaviour
{
    public SwitchGravity switchG;
    public Player pl;
    bool activ2 = false;

    //force la gravité sur le player
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (!activ2)
        {
            if (collision.CompareTag("Player"))
            {
                activ2 = true;
                if (switchG.SensGravity < 0)
                {
                    pl.rb.gravityScale = 3;
                    switchG.Flip();
                    switchG.Rotation();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) activ2 = false;
    }


}

        

