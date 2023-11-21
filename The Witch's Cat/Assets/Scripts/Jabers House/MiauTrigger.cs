using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiauTrigger : MonoBehaviour
{
    [SerializeField]
    private bool destroyAfterTriggered = false;
    private bool canBeTriggered = false;

    private bool isInSpecificArea = false;
    private bool hasEntered = false;

    [SerializeField]
    private UnityEvent OnFirstEnter;

    [SerializeField]
    private UnityEvent OnTrigger;
    [SerializeField]
    
    private void Update()
    {
        // Check if the player is in a specific area and presses the action key
        if (isInSpecificArea && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                OnTrigger?.Invoke();


                if (destroyAfterTriggered)
                    Destroy(this);
            }

           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the flag to indicate that the player is in the specific area
            isInSpecificArea = true;
            if (!hasEntered)
            {
                hasEntered = true;
                OnFirstEnter?.Invoke();
            }
            if (canBeTriggered)
            {
                OnTrigger?.Invoke(); // Invoke the main trigger event
            }
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
    public void ActivateTrigger()
    {
        canBeTriggered = true;
    }

}
