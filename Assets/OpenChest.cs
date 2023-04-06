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
    

    StarCoin starCoin;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] int nombre;

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
        isRange = false;

        for (int i = 0; i < nombre; i++)
        {
            Rigidbody2D prop = Instantiate(rb, transform.position, transform.rotation);
            prop.velocity = new Vector2(2, 5);
        }
        isRange = false;

        //starCoin.Loot();
        //itemCollector.Stars = itemCollector.Stars + starAmount;
        //starsText.text = itemCollector.Stars + "";

    }


}
