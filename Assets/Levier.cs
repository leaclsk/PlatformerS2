using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    //[SerializeField] ZoneSwitchGravity zSwitchGrav;
    //[SerializeField] GravityDownZone gravityDownZone;
    //[SerializeField] GravityUpZone gravityUpZone;
    [SerializeField] GameObject Zone;
    public GravityDownZone gd;
    public GravityUpZone gu;
    int direction;
    int direct;

    private void Start()
    {
        gd = GetComponent<GravityDownZone>();
        //gu = GetComponent<GravityUpZone>();

        //gu.enabled = true;
        //gd.enabled = false;
        //gu = GetComponent<GravityUpZone>().enabled = false;

    }
    private void Update()
    {
        direction = Zone.GetComponent<GravityDownZone>().enabled ? 1 : -1;
        direct = Zone.GetComponent<GravityUpZone>().enabled ? 1 : -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(direction + "" + direct);

            if (direction == 1)
            {
                direction = -1;
                direct = 1;
                Debug.Log(direction + "" + direct);
            }
            if (direct == 1)
            {
                direction = 1;
                direct = -1;
                Debug.Log(direction + "" + direct);
            }

        }
            //if (gu.enabled == true)
            //{
            //    gu.enabled = false;
            //    gd.enabled = true;
            //    Debug.Log("UP");
            //}
            //if (gd.enabled == true)
            //{
            //    gu.enabled = true;
            //    gd.enabled = false;
            //    Debug.Log("DOWN");
            //}



            //zSwitchGrav.SwitchUp = false;//!zSwitchGrav.SwitchUp;
            //zSwitchGrav.SwitchDown = true;//!zSwitchGrav.SwitchDown;
            //Debug.Log("changé");
        
    }
}

