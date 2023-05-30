using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionMenu;
    [SerializeField] ControllerCheck controlCheck;
    bool inOption;
    [SerializeField] Player player;

    void Update()
    {
        if(Input.GetButtonDown(controlCheck.inputPause))
        {
            if(GameIsPaused)
            {
               Resume();
                
            }
            else
            { 
                Pause();
            }
        }

        if(GameIsPaused)
        {
            player.enabled = false;
        }
        else player.enabled = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        inOption = false;

    }

   void Pause()
   {
        if(!inOption) pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

   public void LoadMenu()
   {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
   }

   public void QuitGame()
   {
        Application.Quit();
   }

    public void InOption()
    {
        inOption = true;
    }
}
