using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedStars : MonoBehaviour
{
    SpriteRenderer sr;
    ParticleSystem ps;
    bool collected;
    [SerializeField] GameObject trigger;
    [SerializeField] bool followingStars;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine("Collected");
        }
    }

    public IEnumerator Collected()
    {
        if (!followingStars) Destroy(trigger);
            if (!followingStars) sr.enabled = false;
        ps.Play();
        yield return new WaitForSeconds(0.60f);
        if(!followingStars) Destroy(this);

    }
}
