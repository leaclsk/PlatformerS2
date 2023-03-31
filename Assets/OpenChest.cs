using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    bool isRange = false;
    [SerializeField]Animator animator;

    [SerializeField] private Text starsText;
    [SerializeField] ItemCollector itemCollector;

    [SerializeField] int starAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isRange)
        {
            Chestopening();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isRange = true;
        }
    }
    private void Chestopening()
    {
        animator.SetTrigger("ChestOpen");
        itemCollector.Stars = itemCollector.Stars + starAmount;
        starsText.text = itemCollector.Stars + "";
        isRange = false;
    }


}
