using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarChest : MonoBehaviour
{
    [SerializeField] BoxCollider2D box;
    [SerializeField] CircleCollider2D trigger;
    Rigidbody2D rb;
    [SerializeField] float timer = 0.3f;
    bool canCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canCount = true;
    }

    void Update()
    {
        if (canCount && timer > 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer < 0) trigger.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            box.enabled = true;
            rb.velocity = new Vector2(0, 0);
        }
    }
}