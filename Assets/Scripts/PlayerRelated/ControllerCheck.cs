using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
    [SerializeField] GameObject DeathXbox;
    [SerializeField] GameObject DeathPs4;

    [SerializeField] bool isTutorial;
    [SerializeField] GameObject uiPS4;
    [SerializeField] GameObject uiXBOX;


    public int Xbox_One_Controller = 0;
    public int PS4_Controller = 0;

    public string inputSwitch = "";
    public string inputJump = "";
    public string inputInteraction = "";
    public string inputPause = "";
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            if (names[x].Length == 19 || names[x].Length == 29)
            {
                //print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                //print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }


        if (Xbox_One_Controller == 1)
        {
            inputSwitch = "GravitySwitchXBOX";
            inputJump = "JumpXBOX";
            inputInteraction = "InteractionXBOX";
            inputPause = "pauseXBOX";

            DeathXbox.SetActive(true);
            DeathPs4.SetActive(false);

            if(isTutorial)
            {
                uiXBOX.SetActive(true);
                uiPS4.SetActive(false);
            }

        }
        else if (PS4_Controller == 1)
        {
            inputSwitch = "GravitySwitchPS4";
            inputJump = "JumpPS4";
            inputInteraction = "InteractionPS4";
            inputPause = "pausePS4";

            DeathXbox.SetActive(false);
            DeathPs4.SetActive(true);
            if (isTutorial)
            {
                uiXBOX.SetActive(false);
                uiPS4.SetActive(true);
            }
        }
        else
        {
            inputJump = "Jump";
            inputSwitch = "GravitySwitch";
            inputInteraction = "Interaction";
            inputPause = "pause";
            // there is no controllers
        }
    }
}
