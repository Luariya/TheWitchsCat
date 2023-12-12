using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : MonoBehaviour, IInventoryItem
{
    public string itemName;
    public Sprite itemImage;

    public GameObject interactableTarget;

    public string Name => itemName;
    public Sprite Image => itemImage;

   



   

    public void OnPickup()
    {
        
            Debug.Log($"Picked up {itemName}!");
            Destroy(gameObject); // For example, destroy the item after pickup
       
    }

    internal void SetData(IInventoryItem item, GameObject target)
    {
        itemName = item.Name;
        itemImage = item.Image;
        interactableTarget = target;

    }

    public void UseItem()
    {
        if (interactableTarget != null)
        {
            // Handle interaction (e.g., open a door)
            interactableTarget.SetActive(false);
            Debug.Log($"Used {itemName} on {interactableTarget.name}");

            
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("No interactable target set for this item.");
        }
    }
}
