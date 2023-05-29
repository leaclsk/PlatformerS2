using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // passer au niveau suivant + animation de transition entre niveaux.

    [SerializeField] Animator transition;
    
    public float transitionTime = 2f;

   
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

    }


}
