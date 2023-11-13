using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiauTrigger : MonoBehaviour
{
    [SerializeField]
    private bool destroyAfterTriggered = false;

    private bool isInSpecificArea = false;

    [SerializeField]
    private UnityEvent OnTrigger;

    private void Update()
    {
        // Check if the player is in a specific area and presses the action key
        if (isInSpecificArea && Input.GetMouseButtonDown(0))
        {

            OnTrigger?.Invoke();

            if (destroyAfterTriggered)
                Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the flag to indicate that the player is in the specific area
            isInSpecificArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset flags when the player exits the specific area
            isInSpecificArea = false;
           
        }
    }
   
}
