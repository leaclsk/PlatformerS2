using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem fallParticle;
    [Range(0, 10f)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 10f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    //[SerializeField] float nextfallPS;
    //[SerializeField] float cooldownTime;
    bool activ;

    private void Update()
    {
        counter += Time.deltaTime;

        if(IsGrounded())
        {
            if (activ)
            {
                fallParticle.Play();
                activ = !activ;

            }

            if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
            {
                if (counter > dustFormationPeriod)
                {
                    movementParticle.Play();
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
