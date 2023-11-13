using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staubsaugen1 : MonoBehaviour
{
    public GameObject barrierToDisable;  // Assign the barrier GameObject in the Inspector
    public float disableDuration = 3f;   // Set the duration for the barrier to be disabled

    private bool isBarrierDisabled = false;

    private void Update()
    {
        // Check if the specific object is clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Stecker"))
            {
                // Disable the barrier temporarily
                DisableBarrier();
            }
        }

        // Check if the barrier is disabled and, if so, track the duration
        if (isBarrierDisabled)
        {
            disableDuration -= Time.deltaTime;

            // Check if the duration has elapsed, and if so, enable the barrier again
            if (disableDuration <= 0f)
            {
                EnableBarrier();
            }
        }
    }

    private void DisableBarrier()
    {
        // Check if the barrier exists and is not already disabled
        if (barrierToDisable != null && !isBarrierDisabled)
        {
            // Disable the barrier
            barrierToDisable.SetActive(false);

            // Set the flag to indicate that the barrier is currently disabled
            isBarrierDisabled = true;
        }
    }

    private void EnableBarrier()
    {
        // Check if the barrier exists and is currently disabled
        if (barrierToDisable != null && isBarrierDisabled)
        {
            // Enable the barrier
            barrierToDisable.SetActive(true);

            // Reset the flag and the disable duration
            isBarrierDisabled = false;
            disableDuration = 3f;  // Reset the duration for the next use
        }
    }
}
