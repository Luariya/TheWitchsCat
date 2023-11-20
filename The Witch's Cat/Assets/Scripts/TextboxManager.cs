using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

[System.Serializable]
public class TextboxManager : MonoBehaviour
{
  
    public TextMeshProUGUI monologText; // Change Text to TextMeshProUGUI
    private Queue<string> sentences;
    public TextboxTrigger textboxTrigger;
  

    private void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartMonolog(Monolog monolog)
    {
      
        sentences.Clear();

        foreach (string sentence in monolog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
   

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndMonolog();
            return;
        }

        string sentence = sentences.Dequeue();
        monologText.text = sentence; // Change MonologText to monologText
    }

    void EndMonolog()
    {
        Debug.Log("End of Monolog.");
    }
}
