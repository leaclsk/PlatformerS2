using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioManager audioManager;
    #region TRANSITIONS FIN MENU (FADE OUT)
    [SerializeField] Animator transition;
    Animator animatorMenu;
    [SerializeField] Animator logoAnimation;
    //[SerializeField] Animator FondlogoAnimation;
    [SerializeField] Animator FondlogoAnimation;
    [SerializeField] Animator Planete1;
    [SerializeField] Animator Planete2;
    [SerializeField] Animator Planete3;
    [SerializeField] Animator PiupMaisonLight;
    [SerializeField] Animator playBoutton;
    [SerializeField] Animator optionButton;
    [SerializeField] Animator quitButton;
    [SerializeField] Animator OpenCinematic;
    [SerializeField] ParticleSystem ps;

    
    public float FintransitionTime = 10f;

    #endregion

    #region CINEMATIQUES
    [SerializeField] ControllerCheck controlC;
    public List<VideoPlayer> sceneVideo = new List<VideoPlayer>();
    [SerializeField] int ajout = 0;
    [SerializeField] VideoPlayer video;
    [SerializeField] VideoPlayer video1;
    [SerializeField] VideoPlayer video2;
    [SerializeField] VideoPlayer video3;
    [SerializeField] VideoPlayer video4;
    [SerializeField] VideoPlayer video5;
    [SerializeField] VideoPlayer videoVide;
    [SerializeField] GameObject FondNoir;
    bool isMenuDone =false;

    bool incinematique;
    float timer;
    [SerializeField] GameObject sliderPass;
    [SerializeField] Slider slider;
    [SerializeField] EndLevel endLevel;
    [SerializeField] GameObject passCanva;
    float timeToHoldForPass = 1.3f;
    #endregion


    public float transitionTime = 1.30f;


    bool pass;

    float timerBetween;
    float timerBetweenRef = 2;
    private void Start()
    {
        audioManager.PlayMusic();

        Screen.SetResolution(1920, 1080, true);

        #region GETCOMPONENT ELEMENTS MENU
        ps = GameObject.Find("ParticlesSys").GetComponent<ParticleSystem>();

        FondlogoAnimation = GameObject.Find("FondLogo").GetComponent<Animator>();
   
        Planete1 = GameObject.Find("Planete1").GetComponent<Animator>();
       
        Planete2 = GameObject.Find("Planete2").GetComponent<Animator>();
    
        Planete3 = GameObject.Find("Planete3").GetComponent<Animator>();

        PiupMaisonLight = GameObject.Find("PlanetePiupLum").GetComponent<Animator>();

        logoAnimation = GameObject.Find("LogoAnimation").GetComponent<Animator>();

        playBoutton = GameObject.Find("Play").GetComponent<Animator>();
        optionButton = GameObject.Find("Option").GetComponent<Animator>();
        quitButton = GameObject.Find("Quit").GetComponent<Animator>();

        OpenCinematic = GameObject.Find("OpenCinematic").GetComponent<Animator>();
        #endregion

        #region LIST VIDEOS CINEMATIQUE
        sceneVideo.Add(video1);
        sceneVideo.Add(video2);
        sceneVideo.Add(video3);
        sceneVideo.Add(video4);
        sceneVideo.Add(video5);
        sceneVideo.Add(videoVide);
        video = sceneVideo[0];
#endregion


    }
    private void Update()
    {
      
        if(pass && timerBetween < timerBetweenRef)
        {
            slider.value = 0;
            timerBetween += Time.deltaTime;
            if (timerBetween > timerBetweenRef) timerBetween = timerBetweenRef;
            if (timerBetween == timerBetweenRef)
            {
                pass = false;
                timerBetween = 0;
            }
        }

        if (incinematique && Input.GetButton(controlC.inputJump) && !pass)
        {
            sliderPass.SetActive(true);
            timer += Time.deltaTime;
            slider.value = timer;
            if (timer > timeToHoldForPass) timer = timeToHoldForPass;
            if (timer == timeToHoldForPass)
            {
                video = sceneVideo[+ajout];
                PlayVideo();

                if (ajout == 6)
                {
                    endLevel.StartCoroutine(endLevel.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                }
            }
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime * 1.5f;
                slider.value = timer;

            }
            if (timer < 0)  timer = 0;
            //if (timer == 0) sliderPass.SetActive(false);
        }

    }
    public void PlayCinematic()
    {  
        StartCoroutine("FinMenu");
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void QuitGame()
    {
        Application.Quit();

    }
   

    IEnumerator FinMenu()
    {
        #region ANIM FADE OUT MENU
        ps.Stop();
        Planete1.SetBool("FinMenu", true);
        OpenCinematic.SetBool("FinMenu", true);
        FondlogoAnimation.SetBool("FondMenu", true);
        logoAnimation.SetBool("FinMenu", true);
        Planete1.SetBool("FinMenu", true);
        Planete2.SetBool("FinMenu", true);
        Planete3.SetBool("FinMenu", true);
        PiupMaisonLight.SetBool("FinMenu", true);
        playBoutton.SetBool("FinMenu", true);
        optionButton.SetBool("FinMenu", true);
        quitButton.SetBool("FinMenu", true);
        OpenCinematic.SetBool("FinMenu", true);
        #endregion

        yield return new WaitForSeconds(3f); // attends la fin du fadeout
        
        if(!isMenuDone)PlayVideo();
        incinematique = true;
        passCanva.SetActive(true);

        FondNoir.SetActive(true);

        isMenuDone = true; //lancer les autres cinematiques

        //yield return new WaitForSeconds(transitionTime);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //transition.SetBool("Start", false);

    }
    void PlayVideo()
    {
        video.Play();
        ajout++;
        timer = 0;
        pass = true;
    }
}
