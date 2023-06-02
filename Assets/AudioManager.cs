using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioBoss;
    [SerializeField] bool isBossScene;
    
    void Start()
    {
        if (isBossScene)
        {
            audioBoss.Play();

        }
        else audioSource.Play();
    }

    
    void Update()
    {
        
    }
}
