using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ListCinematique : MonoBehaviour
{
    [SerializeField] EndLevel endLevel;
    [SerializeField] ControllerCheck controlC;
    public List<VideoPlayer> sceneVideo = new List<VideoPlayer>();

    [SerializeField] VideoPlayer video;
    [SerializeField] VideoPlayer video1;
    [SerializeField] VideoPlayer video2;
    [SerializeField] VideoPlayer video3;
    [SerializeField] VideoPlayer video4;
    [SerializeField] VideoPlayer video5;
    [SerializeField] VideoPlayer video6;
    [SerializeField] VideoPlayer video7;
    [SerializeField] VideoPlayer videoVide;

    [SerializeField] int ajout = 0;
    void Start()
    {
        sceneVideo.Add(video1);
        sceneVideo.Add(video2);
        sceneVideo.Add(video3);
        sceneVideo.Add(video4);
        sceneVideo.Add(video5);
        sceneVideo.Add(video6);
        sceneVideo.Add(video7);
        sceneVideo.Add(videoVide);
        video = sceneVideo[0];
        PlayVideo();
    }


    void Update()
    {


        if (Input.GetButtonDown(controlC.inputJump))
        {
            video = sceneVideo[+ajout];
            PlayVideo();
            

            if (ajout == 8)
            {
                
                endLevel.StartCoroutine(endLevel.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        
    }

    void PlayVideo()
    {
        video.Play();
        ajout++;
    }
}
