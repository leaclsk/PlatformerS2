using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class MainMenu : MonoBehaviour
{
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
    public float transitionTime = 1.30f;

    private void Start()
    {
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



    }
    public void PlayCinematic()
    {
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
    }
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //transition.SetBool("Start", false);

    }
}
