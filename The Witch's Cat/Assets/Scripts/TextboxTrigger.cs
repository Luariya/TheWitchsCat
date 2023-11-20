using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class TextboxTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject meowTextPanel; // Reference to the MeowTextPanel GameObject
    [SerializeField]
    private TextMeshProUGUI textComponent = null;

    public string[] lines = null;
    public float textSpeed = 0.3f;
   
    private bool allowNextLine = true;

    private int index = 0;
    private void Start()
    {
        if (meowTextPanel != null)
        {
            meowTextPanel.SetActive(false); // Ensure the panel starts as inactive
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
            meowTextPanel.SetActive(false);
        }
    }

    void StartMonologue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
}