using System.Collections;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject textboxPanel;
    public float textSpeed = 0.3f;

    private void Start()
    {
        HideText();
    }

    public void ShowInitialText()
    {
        ShowText();
        StartCoroutine(TypeLine("Initial Monolog Line 1"));
    }

    public void ShowCharacterClickedText()
    {
        ShowText();
        StartCoroutine(TypeLine("Character Clicked Line 1"));
    }

    public void HideText()
    {
        textboxPanel.SetActive(false);
    }

    public void ShowText()
    {
        textboxPanel.SetActive(true);
    }

    public IEnumerator TypeLine(string line)
    {
        textComponent.text = string.Empty;

        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
