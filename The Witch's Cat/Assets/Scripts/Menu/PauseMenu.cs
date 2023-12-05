using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Miau miauScript;


    private bool isPaused = false;

  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Freeze the game

        // Disable the Miau script
        if (miauScript != null)
        {
            miauScript.enabled = false;
        }

        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the game

        // Enable the Miau script
        if (miauScript != null)
        {
            miauScript.enabled = true;
        }

        isPaused = false;
    }
}
