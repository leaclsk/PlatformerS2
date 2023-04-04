using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] ZoneSwitchGravity zSwitchGrav;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            zSwitchGrav.SwitchUp = false;//!zSwitchGrav.SwitchUp;
            zSwitchGrav.SwitchDown = true;//!zSwitchGrav.SwitchDown;
            Debug.Log("changé");
        }
    }
}

