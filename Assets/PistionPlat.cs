using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistionPlat : MonoBehaviour
{
    [SerializeField] float movement = 1f;
    [SerializeField] float cooldownTime;
    [SerializeField] float nextPuch;
    bool puchside = true;

    void Update()
    {
        if(puchside) // montée
        {
            if (Time.time > nextPuch)
            {
                transform.Translate(0, movement, 0);
                nextPuch = Time.time + cooldownTime;
                puchside = !puchside;
            }
        }
        if (!puchside) // descente
        {
            if (Time.time > nextPuch)
            {
                transform.Translate(0, -movement, 0);
                nextPuch = Time.time + cooldownTime;
                puchside = !puchside;
            }
        }


    }

}
