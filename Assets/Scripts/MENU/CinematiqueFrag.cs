using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematiqueFrag : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] EndLevel endLevel;
    [SerializeField] float timer;
    void Start()
    {
        StartCoroutine("Fragement");
    }

    
    void Update()
    {
        
    }
    public IEnumerator Fragement()
    {
        
        yield return new WaitForSeconds(1f);

        video.Play();
        yield return new WaitForSeconds(timer);
      
        StartCoroutine(endLevel.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      

    }
}