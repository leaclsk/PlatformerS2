using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFrag : MonoBehaviour
{
    Player player;
    [SerializeField] Animator animator;
    
    //[SerializeField] Animator lightAnimator;
    [SerializeField] GameObject lightAnimator;
    Turn turn;
    CapsuleCollider2D fragCollider;
    



    private void Start()
    {
        turn = GetComponent<Turn>();
        player = GameObject.Find("Piup").GetComponent<Player>();
        fragCollider = GetComponent<CapsuleCollider2D>();
        
    }
    private void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine("CollectingFragment");
        }
    }

    IEnumerator CollectingFragment()
    {
        player.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        fragCollider.enabled = false;
        turn.enabled = false;
        Destroy(lightAnimator);
        animator.SetBool("Collected", true);
        yield return new WaitForSeconds(2f);
        player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        

    }

}
