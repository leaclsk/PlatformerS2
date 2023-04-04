using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneSwitchGravity : MonoBehaviour
{
    public SwitchGravity switchG;
    public Player pl;
    bool activ = false;
    bool activ2 = false;
    public bool SwitchUp = true;
    public bool SwitchDown = false;
    SpriteRenderer sr;

    //force la gravité sur le player
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SwitchUp)
            {

                //activ = true;
                if (switchG.SensGravity > 0)
                {
                    pl.rb.gravityScale = -3;
                    switchG.Flip();
                    switchG.Rotation();
                    sr.color = new Color32(125, 93, 93, 140);
                    Debug.Log("rouge");
                }

            }

            if (SwitchDown)
            {

                //activ2 = true;
                if (switchG.SensGravity < 0)
                {
                    pl.rb.gravityScale = 3;
                    switchG.Flip();
                    switchG.Rotation();
                    sr.color = new Color32(93, 120, 125, 140);
                    Debug.Log("bleu");
                }


            }

        }
    }
        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) SwitchDown = false; SwitchDown = false;

        //if (SwitchDown) SwitchDown = false; //SwitchUp = true;
        //if (SwitchUp) SwitchUp = false; //SwitchDown = true;

        }
    
}