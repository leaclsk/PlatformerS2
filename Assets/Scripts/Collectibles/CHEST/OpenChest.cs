using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class OpenChest : MonoBehaviour
{
    [SerializeField] ControllerCheck controllerCheck;
    bool isRange = false;
    [SerializeField] Animator animator;
    [SerializeField] private Text starsText;
    [SerializeField] ItemCollector itemCollector;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] int nombre;
    //ParticleSystem ps;

    [SerializeField] GameObject openLight;
   public bool open = false;
    [SerializeField] float timer;
    [SerializeField] float timeLight;
    Animator animLight;

    [SerializeField] GameObject overLight;
    Animator overLightAnim;




    void Start()
    {
        timer = 0;
        animLight = openLight.GetComponentInChildren<Animator>();
        overLightAnim = overLight.GetComponentInChildren<Animator>();
        //    ps = gameObject.GetComponent<ParticleSystem>();   
        //openLight = GetComponent<Light2D>();

    }

    

     
    void Update()
    {
        if (Input.GetButton(controllerCheck.inputInteraction) && isRange)
        {
            Chestopening();
        }

        if (timer > 0 && open)
        {
            openLight.SetActive(true);
            timer -= Time.deltaTime;
        }

        if (timer < 0) timer = 0;
        if (timer == 0)
        {
            
            open = false;
            animLight.SetTrigger("FadeOut");

            //openLight.SetActive(false);
            //openLight.intensity = Mathf.SmoothStep(0.30f, 0, 2f);
            timer = timeLight;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = true;

        }
    }
    private void Chestopening()
    {
        overLightAnim.SetTrigger("FadeOut");
        open = true;
        //openLight.intensity = 0.30f;

        animator.SetTrigger("ChestOpen");


        isRange = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        for (int i = 0; i < nombre; i++)
        {
            Rigidbody2D prop = Instantiate(rb, transform.position, transform.rotation);
            prop.velocity = new Vector2(Random.Range(-3, 3), Random.Range(6, 7));
        }
        isRange = false;

        //ps.Stop();
       

    }

}


