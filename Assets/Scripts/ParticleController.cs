using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem FallPositiv;
    [SerializeField] ParticleSystem movementParticleLeft;
    [SerializeField] ParticleSystem movementParticleRight;
    [SerializeField] ParticleSystem fallParticle;
    [SerializeField] ParticleSystem frontfallParticle;
    [SerializeField] ParticleSystem fallParticleLeft;
    [SerializeField] ParticleSystem fallParticleright;
    [Range(0, 10f)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 10f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] ControllerCheck controlC;

    float counter;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    

    //[SerializeField] float nextfallPS;
    //[SerializeField] float cooldownTime;
    bool activ;

    private void Start()
    {
        
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(playerRb.velocity.y > 0 && playerRb.gravityScale > 0 && Input.GetButtonUp(controlC.inputSwitch))
        {
            FallPositiv.Play();
        }
        if (playerRb.velocity.y < 0 && playerRb.gravityScale < 0 && Input.GetButtonUp(controlC.inputSwitch))
        {
            FallPositiv.Stop();
        }

        if (IsGrounded())
        {
            FallPositiv.Stop();

            if (activ && playerRb.velocity.x > 0)
            {
                fallParticleLeft.Play();
                frontfallParticle.Play();
                activ = !activ;

            }
            else if(activ && playerRb.velocity.x < 0)
            {
                fallParticleright.Play();
                activ = !activ;
            }
            if (activ)
            {
                fallParticle.Play();
                frontfallParticle.Play();
                activ = !activ;

            }

            if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
            {
                if (counter > dustFormationPeriod)
                {
                    if (playerRb.velocity.x > 0)
                    {
                        movementParticleLeft.Play();
                    }
                    if (playerRb.velocity.x < 0)
                    {
                        movementParticleRight.Play();
                    }

                    counter = 0;
                }
            }
        }

        if(!IsGrounded())
        {
            activ = true;
        }
    }

  
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }


}
