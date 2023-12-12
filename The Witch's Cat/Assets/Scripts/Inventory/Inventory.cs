using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 10;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    private static Inventory instance;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(Inventory).Name;
                    instance = obj.AddComponent<Inventory>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                    Debug.Log("Item added");
                }
            }
        }
    }
}
