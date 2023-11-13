using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miau : MonoBehaviour
{
    public AudioClip clickSound; // Attach your audio clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if it doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {
        // Check if the mouse button clicked is the left button (button index 0)
        if (Input.GetMouseButtonDown(0))
        {
            PlayClickSound();
        }
    }

    void PlayClickSound()
    {
        // Check if an audio clip is assigned
        if (clickSound != null)
        {
            // Play the assigned audio clip
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for the click sound.");
        }
    }
}