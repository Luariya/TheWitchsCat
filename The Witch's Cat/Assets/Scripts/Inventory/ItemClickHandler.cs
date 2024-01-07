using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;

    private SimpleItem myItem;

    public void Start()
    {
        myItem = GetComponent<SimpleItem>();
    }
    public void OnItemClicked()
    {
        Debug.Log(myItem.Name);

        //myItem.UseItem();

        _Inventory.selectedItem = myItem;

    }
}
