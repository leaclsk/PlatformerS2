using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starFragCine : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool lastFrag;
    void Start()
    {
        if(!lastFrag)
        {
            StartCoroutine("SoundFrag");
        }else if (lastFrag)
        {
            StartCoroutine("LastSoundFrag");
        }


    }

    IEnumerator SoundFrag()
    {
        yield return new WaitForSeconds(2f);
        audioSource.Play();
    }
    IEnumerator LastSoundFrag()
    {
        yield return new WaitForSeconds(11f);
        audioSource.Play();
    }
}
