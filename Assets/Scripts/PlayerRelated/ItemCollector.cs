using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] public int Stars = 0;
    [SerializeField] AudioSource audioSourceStars;
    [SerializeField] AudioSource audioSourceHeal;

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
            if (!audioSourceStars.isPlaying)
            {
                audioSourceStars.Play();
            }
               
            Stars++;
                
            }

            if(collision.gameObject.CompareTag("FollowingStar"))
            {
            if (!audioSourceHeal.isPlaying)
            {
                audioSourceHeal.Play();
            }
            }

        

    }

    
}
