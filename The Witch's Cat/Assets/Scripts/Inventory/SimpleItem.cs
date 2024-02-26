using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleItem : MonoBehaviour, IInventoryItem
{
    public string itemName;
    public Sprite itemImage;
    public Activatable myInteractable;
    public UnityEvent onCollected;

    public string Name => itemName;
    public Sprite Image => itemImage;
    public Activatable MyActivatable => myInteractable ;

    public bool destroyOnPickUp = true;

    public void OnPickup()
    {
        
            Debug.Log($"Picked up {itemName}!");
        onCollected?.Invoke();
        if(destroyOnPickUp)
            Destroy(gameObject); 

       
    }

    internal void SetData(IInventoryItem item, GameObject target)
    {
        itemName = item.Name;
        itemImage = item.Image;
        myInteractable = item.MyActivatable;

    }

    public void UseItem()
    {

        itemName = "";
        itemImage = null;
        myInteractable = null;

        Image image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = itemImage;
        image.enabled = false;


    }
}
