using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : MonoBehaviour, IInventoryItem
{
    public string itemName;
    public Sprite itemImage;
    public Activatable myInteractable;


    public string Name => itemName;
    public Sprite Image => itemImage;
    public Activatable MyActivatable => myInteractable ;

    public void OnPickup()
    {
        
            Debug.Log($"Picked up {itemName}!");
            Destroy(gameObject); // For example, destroy the item after pickup
       
    }

    internal void SetData(IInventoryItem item, GameObject target)
    {
        itemName = item.Name;
        itemImage = item.Image;
        myInteractable = item.MyActivatable;

    }

    public void UseItem()
    {
        Destroy(gameObject);
    }
}
