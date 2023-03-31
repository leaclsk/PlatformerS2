using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StarCoin : MonoBehaviour
{

    bool open = false;

    #region Loot Spawn
    [SerializeField]private List<GameObject> loot = new List<GameObject>();
    [SerializeField]
    [Range(1, 10)]
    private int minNumber = 7;
    [SerializeField]
    [Range(2, 100)]
    private int maxNumber = 20;
    [SerializeField]
    private Transform spawnPoint;
    private bool hasBeenCollected = false;

    [SerializeField]
    [Header("Click to Spawn")]
    public bool spawnLoot = false;
    #endregion

    #region Chest Open
    bool isRange = false;
    [SerializeField] Animator animator;

    [SerializeField] private Text starsText;
    [SerializeField] ItemCollector itemCollector;

    [SerializeField] int starAmount;

    StarCoin starCoin;
    #endregion


    private void OnValidate()
    {
        if(minNumber > maxNumber)
        {
            maxNumber = minNumber + 1;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isRange)
        {
            Chestopening();
            spawnLoot = true;
        }
        
        
            if (spawnLoot && !hasBeenCollected)
            {
                spawnLoot = false;
                Loot();

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
        Loot();
        

        //itemCollector.Stars = itemCollector.Stars + starAmount;
        //starsText.text = itemCollector.Stars + "";
        isRange = false;
    }

    #region Loot 
    public void Loot()
    {
        
        
            hasBeenCollected = true;
            int number = Random.Range(minNumber, maxNumber);
            StartCoroutine(CreateLoot(number));
        
           
    }

    IEnumerator CreateLoot(int number)
    {  
        for( int i = 0 ; i < number ; i++)
        {
            GameObject tempLoot = Instantiate(loot[Random.Range(0, loot.Count)]);
            tempLoot.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(0.1f);
            
            
        }
    }
    #endregion
}
