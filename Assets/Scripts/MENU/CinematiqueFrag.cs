using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematiqueFrag : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] GameObject videoCine;
    [SerializeField] Animator fondNoir;
    [SerializeField] EndLevel endLevel;
    [SerializeField] float timer;

    [SerializeField] bool IsLastCine;
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

        if (!IsLastCine)
        {
            StartCoroutine(endLevel.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
           

        videoCine.SetActive(false);
        if(IsLastCine)
        {
            fondNoir.SetTrigger("FadeOut");

        }


    }
}
