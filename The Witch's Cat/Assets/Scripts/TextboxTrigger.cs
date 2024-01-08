using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextboxTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject TextPanel; // Reference to the MeowTextPanel GameObject
    [SerializeField]
    private TextMeshProUGUI textComponent = null;

    public string[] lines = null;
    public float textSpeed = 0f;

    private bool allowNextLine = true;

    private int index = 0;

    private void Start()
    {
        if (TextPanel != null)
        {
            TextPanel.SetActive(false); // Ensure the panel starts as inactive
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (textComponent.text == lines[index] && allowNextLine)
            {
                allowNextLine = false;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            allowNextLine = true;
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            TextPanel.SetActive(false);
        }
    }

    public void StartMonologue()
    {
        index = 0;
        textComponent.text = lines[index]; // Display the entire line immediately
        TextPanel.SetActive(true); // Make sure the panel is active

        // After displaying the first line, allow the next line
        allowNextLine = true;
    }

    IEnumerator TypeLineWithDelay()
    {
        yield return new WaitForSeconds(textSpeed); // Add a delay before typing the line

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            TextPanel.SetActive(false);
        }
    }

    IEnumerator TypeFirstLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // After typing the first line, allow the next line
        allowNextLine = true;
    }
}