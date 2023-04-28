using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    //[SerializeField] Player player;
    [SerializeField] ControllerCheck controllerCheck;
    bool isRange = false;
    [SerializeField] Animator animator;
    [SerializeField] private Text starsText;
    [SerializeField] ItemCollector itemCollector;
    [SerializeField] int starAmount;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int nombre;
    ParticleSystem ps;
    //[SerializeField] Transform tr;

    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;

    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;
    [SerializeField]bool shaking = true;

    void Start()
    {
        _startPos = transform.position;
        //controllerCheck = GetComponent<ControllerCheck>();
        ps = gameObject.GetComponent<ParticleSystem>();
        //tr = gameObject.GetComponent<Transform>();

        if(shaking)
        {
            Begin();
        }
       
    }
    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }
    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

     
    void Update()
    {
        if (Input.GetButton(controllerCheck.inputInteraction) && isRange)
        {
            Chestopening();
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
        animator.SetTrigger("ChestOpen");
        isRange = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        for (int i = 0; i < nombre; i++)
        {
            Rigidbody2D prop = Instantiate(rb, transform.position, transform.rotation);
            prop.velocity = new Vector2(Random.Range(-5, 5), Random.Range(3, 5));
        }
        isRange = false;

        ps.Stop();
        shaking = false;

        //starCoin.Loot();
        //itemCollector.Stars = itemCollector.Stars + starAmount;
        //starsText.text = itemCollector.Stars + "";

    }
    private IEnumerator Shake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            transform.position = _randomPos;

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }

        transform.position = _startPos;
    }

}


