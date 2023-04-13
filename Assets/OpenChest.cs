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
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int nombre;
    ParticleSystem ps;
    [SerializeField] ControllerCheck controlC;

    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(controlC.inputInteraction) && isRange)
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
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        for (int i = 0; i < nombre; i++)
        {
            Rigidbody2D prop = Instantiate(rb, transform.position, transform.rotation);
            prop.velocity = new Vector2(Random.Range(-5, 5), Random.Range(3,5));
        }
        isRange = false;

        ps.Stop();


        //starCoin.Loot();
        //itemCollector.Stars = itemCollector.Stars + starAmount;
        //starsText.text = itemCollector.Stars + "";

    }


}
