using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_stars : MonoBehaviour
{
    private TextMeshProUGUI starText;



    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
    }
   
    public void UpdateStarText(PlayerInventory inventory)
    {
        starText.text = inventory.NumberOfStars.ToString();
    }
    
}
