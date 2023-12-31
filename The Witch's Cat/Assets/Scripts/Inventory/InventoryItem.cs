using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    string Name { get;  }

    Sprite Image { get;  }

    Activatable MyActivatable { get;  }

    void OnPickup();
   
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs (IInventoryItem item)
    {
        Item = item;
        Debug.Log("picked up");
    }

    public IInventoryItem Item; 
}