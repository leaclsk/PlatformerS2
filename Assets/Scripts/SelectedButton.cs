using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedButton : MonoBehaviour
{
    bool activ;
    [SerializeField] GameObject currentSelected;
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool option;
    [SerializeField] bool play;
    [SerializeField] bool quit;


    void Update()
        {
            currentSelected = EventSystem.current.currentSelectedGameObject;
        if(option)
        {
            if (currentSelected.name == "Option" && activ)
            {
                audioSource.Play();
                activ = !activ;
                if (currentSelected.name == "Play" || currentSelected.name == "Option" && activ) activ = true;
            }
        }
        if (play)
        {
            if (currentSelected.name == "Play" && activ)
            {
                audioSource.Play();
                activ = !activ;
                if (!(currentSelected.name == "Play") && activ) activ = true;
            }
        }
        if (quit)
        {
            if (currentSelected.name == "Quit" && activ)
            {
                audioSource.Play();
                activ = !activ;
                if (!(currentSelected.name == "Quit") && activ) activ = true;
            }
        }


    }
    
}
