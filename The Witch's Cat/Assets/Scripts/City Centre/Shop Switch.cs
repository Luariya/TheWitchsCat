using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwitch : MonoBehaviour
{
    [SerializeField] private GameObject objectToSwitch; // The object to switch on/off
    [SerializeField] private bool startsActive = true; // Whether the object starts as active or not

    private void Start()
    {
        // Set the initial state of the object based on startsActive
        objectToSwitch.SetActive(startsActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Switch the object off
            objectToSwitch.SetActive(false);
            Debug.Log("Player entered trigger, object switched OFF");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            // Switch the object on
            objectToSwitch.SetActive(true);
            Debug.Log("Player exited trigger, object switched ON");
        }
    }
}
