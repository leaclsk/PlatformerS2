using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int Stars = 0;
    
    [SerializeField] private Text starsText;
    [SerializeField] ChangeZone changeZone;
    

    private void Start()
    {

        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
            if (collision.gameObject.CompareTag("Star"))
            { 
                Destroy(collision.gameObject);
                Stars++;
                starsText.text = Stars + "";
            }

        if (collision.gameObject.CompareTag("ButtonChangeZone"))
        {
            Destroy(collision.gameObject);
            changeZone.change = false;
            
        }
        

    }
    
}
