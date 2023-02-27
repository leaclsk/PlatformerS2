using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfStars { get; private set; }

    [SerializeField] public UnityEvent<PlayerInventory> OnStarCollected;
    public void StarCollected()
    {
        NumberOfStars++;
        Debug.Log(NumberOfStars);
        OnStarCollected.Invoke(this);
    }

}
