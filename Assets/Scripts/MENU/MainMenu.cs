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
    public float transitionTime = 1.30f;

    private void Start()
    {
        logoAnimation = GetComponent<Animator>();
        animatorMenu = GetComponent<Animator>();
        //MainMenu = GameObject.Find("Piup").GetComponent<Player>();
    }
    public void PlayCinematic()
    {
        logoAnimation.SetBool("FinMenu", true);
        animatorMenu.SetBool("FinMenu", true);
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
