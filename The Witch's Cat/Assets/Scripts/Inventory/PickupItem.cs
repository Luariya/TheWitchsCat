using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Assuming left mouse button is clicked
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Inventory.Instance.AddItem(GetComponent<IInventoryItem>());
            Destroy(gameObject); // Deactivate the item in the scene
        }
    }
}
