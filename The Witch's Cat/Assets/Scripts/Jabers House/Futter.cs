using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futter : MonoBehaviour
{
    public Color newColor = Color.red; // Set the new color in the Inspector
    public GameObject objectToChange; // Assign the object to change in the Inspector
    public GameObject objectToDestroy; // Assign the object to destroy in the Inspector
    private bool hasChanged = false;
    private bool isInSpecificArea = false;

    private void Update()
    {
        // Check if the player is in a specific area and presses the action key
        if (isInSpecificArea && Input.GetMouseButtonDown(0) && !hasChanged)
        {
            // Change the color of the specified object
            ChangeObject();

            // Destroy the third object
            DestroyObject();

            hasChanged = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Futter"))
        {
            // Set the flag to indicate that the player is in the specific area
            isInSpecificArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Futter"))
        {
            // Reset flags when the player exits the specific area
            isInSpecificArea = false;
           
        }
    }

    private void ChangeObject()
    {
        // Change the color of the specified object
        if (objectToChange != null)
        {
            objectToChange.GetComponent<Renderer>().material.color = newColor;

            // Set the flag to indicate that the object has changed
            hasChanged = true;
        }
    }

    private void DestroyObject()
    {
        // Destroy the third object
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }

   
}
