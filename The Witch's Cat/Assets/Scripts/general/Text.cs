using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Text : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI textComponent = null;

    public string[] lines = null;
    public float textSpeed = 0.3f;
    public GameObject TextboxPanel;

    private bool allowNextLine = true;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartMonologue(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
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

        if(Input.GetMouseButtonUp(0))
        {

            allowNextLine = true;
        }
    }

    void StartMonologue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine ()
    {
        if (index < lines.Length - 1 )
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            TextboxPanel.SetActive(false);
        }
    }
}
