using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]public PlayerHealth heal;
    [SerializeField] int speed;
    bool rotation = false;
    ParticleSystem ps;


    private void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Pause();
        GetComponent<SpriteRenderer>().color = new Color32(80, 80, 80, 255);
    }

    private void Update()
    {
        if(rotation)
        {
            transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime*speed);
           
            ps.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(heal.PosRespawn);
            heal.PosRespawn = gameObject.transform.position;
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            rotation = true;
            

        }
    
    
    }
}
