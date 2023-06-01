using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUpZone : MonoBehaviour
{
    public SwitchGravity switchG;
    public Player pl;
    bool activ = false;
    
    //force la gravité sur le player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activ)
        {
            if (collision.CompareTag("Player"))
            {
                activ = true;
                if (switchG.SensGravity > 0)
                {
                    pl.rb.gravityScale = -3;
                    switchG.Flip();
                    switchG.Rotation();
                }
                
            }



        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) activ = false;
        
    }
}
