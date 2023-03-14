using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZone : MonoBehaviour
{
    public SwitchGravity switchG;
    public Player pl;
    bool activ3 = false;
    [SerializeField] public bool change;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (change && !activ3)
        {
            if (collision.CompareTag("Player"))
            {
                activ3 = true;
                if (switchG.SensGravity < 0)
                {
                    pl.rb.gravityScale = 3;
                    switchG.Flip();
                    switchG.Rotation();
                }

            }

        }
        if (!change && !activ3)
        {
            if (collision.CompareTag("Player"))
            {
                activ3 = true;
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
        if (collision.CompareTag("Player")) activ3 = false;

    }
}

