using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatNip : MonoBehaviour
{
    private bool canMove = true;
    private bool hasEntered = false;
    [SerializeField]
    private UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canMove && !hasEntered)
        {
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Freeze all constraints (position and rotation)
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

                // Set the flag to indicate the player has entered
                hasEntered = true;
                OnTrigger?.Invoke();
            }
        }
    }

    private void Update()
    {
       
    }

    private void ResumeMovement()
    {
        // Set the flag to allow movement
        canMove = true;

        // Find the player object
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Unfreeze all constraints
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

       
    }
}


