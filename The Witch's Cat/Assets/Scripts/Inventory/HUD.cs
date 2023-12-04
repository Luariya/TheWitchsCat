using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    public Transform inventoryPanel;

    private void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)

    {
        Debug.Log("Checking slot in inventoryPanel!");
        Transform inventoryPanel = transform.Find("inventoryPanel");
        if (inventoryPanel == null)
        {
            Debug.LogError("Inventory panel not found.");
            return;
        }
        foreach (Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if(image != null && !image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                Debug.Log("in Inventory");

                break;
            }
        }
    }
}
