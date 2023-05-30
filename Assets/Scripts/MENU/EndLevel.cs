using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndLevel : MonoBehaviour
{
    // passer au niveau suivant + animation de transition entre niveaux.

    [SerializeField] Animator transition;  
    public float transitionTime = 2f;

    public Slider slider;
    static public float mainVolume;
    static public float sliderVolume;
    public AudioMixer audioMixer;
    public ItemCollector itemCollector;

    private void Start()
    {
        Time.timeScale = 1f;
        itemCollector.Stars = ItemCollector.totalStars;
        audioMixer.SetFloat("volume", mainVolume);
        slider.value = sliderVolume;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        }
    }
    public IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        //transition.SetBool("Start", false);

        sliderVolume = slider.value;
        audioMixer.GetFloat("volume", out mainVolume);
       
        ItemCollector.totalStars = itemCollector.Stars;


    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


}
