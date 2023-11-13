using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class A : MonoBehaviour
{
    private bool canMove = true;
    private bool hasEntered = false;

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
            }
        }
    }

    private void Update()
    {
        // Check if a specific asset is clicked (e.g., a button)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("clock"))
            {
                // Resume movement only if the specific asset is clicked
                ResumeMovement();
            }
        }
    }

    private void ResumeMovement()
    {
        // Set the flag to allow movement
        canMove = true;

        // Find the player object (you can customize this based on your setup)
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

