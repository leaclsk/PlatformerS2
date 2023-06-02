using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] public int Stars = 0;
    [SerializeField] AudioSource audioSource;
    
    public Text starsText;

    public static int totalStars = 0;
   // [SerializeField] ChangeZone changeZone;
    

    private void Start()
    {
    
    }

    private void Update()
    {
        starsText.text = Stars + "";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
            if (collision.gameObject.CompareTag("Star"))
            {
            audioSource.Play();
            Stars++;
                
            }

        

    }

    
}
