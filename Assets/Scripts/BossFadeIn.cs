using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFadeIn : MonoBehaviour
{
    Player player;
    [SerializeField] Animator fangenAnim;
    [SerializeField] Animator fangenRunAnim;
    [SerializeField] Animator speedCam;
    GameObject cam;
    GameObject fangen;
    [SerializeField] GameObject fangenRun;
    [SerializeField] ParticleSystem ps;
    float timer;
    [SerializeField] float timeBetweenTurn;

    bool inChase;
    [SerializeField] float cameraSpeedDuringTurn = 1.8f;


    bool pass;
    void Start()
    {
        
        timer = timeBetweenTurn;
        cam = GameObject.Find("Camera");
        fangen = GameObject.Find("FANGEN");
        player = GameObject.Find("Piup").GetComponent<Player>();
    }

    private void Update()
    {
        if(inChase && timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0) timer = 0;
            if (timer == 0)
            {
                StartCoroutine("TurningMoment");
                timer = timeBetweenTurn;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")  && !pass) //&& player.IsGrounded()
        {

            pass = true;
            StartCoroutine("BeginChase");

        }
    }

    IEnumerator BeginChase()
    {
        player.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        fangenAnim.SetBool("FangenIn", true);
        yield return new WaitForSeconds(1.75f);
        fangen.SetActive(false);
        fangenRun.SetActive(true);
        inChase = true;
        player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator TurningMoment ()
    {
        fangenRunAnim.SetTrigger("Turning");
        
        speedCam.speed = cameraSpeedDuringTurn;
        yield return new WaitForSeconds(1.5f);
        
        speedCam.speed = Mathf.SmoothStep(speedCam.speed, 1, 1f); //ne marche pas pour raison inconnue

    }
    
}
