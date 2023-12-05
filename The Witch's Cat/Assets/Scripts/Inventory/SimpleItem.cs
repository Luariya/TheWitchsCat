using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : MonoBehaviour, IInventoryItem
{
    public string itemName;
    public Sprite itemImage;

    public string Name => itemName;
    public Sprite Image => itemImage;

   

    public void OnPickup()
    {
        
            Debug.Log($"Picked up {itemName}!");
            Destroy(gameObject); // For example, destroy the item after pickup
       
    }
}
