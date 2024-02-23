using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickTrigger : MonoBehaviour
{
    [SerializeField] private bool destroyAfterTriggered = false;
   
    [SerializeField] private int neededActivations = 0;
    private int currentActivations = 0;
    public string NextLevels;
    private bool isTextActive = false;
    [SerializeField] private UnityEvent OnTrigger;
   
    private void Update()
    {
        // Check if the left mouse button is clicked
        if ( !isTextActive && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Clicked on SimpleItem");
                OnTrigger?.Invoke();

                if (destroyAfterTriggered)
                    Destroy(gameObject);
            }
        }
    }

    public void ActivateTrigger()
    {
        currentActivations++;
        if(currentActivations >= neededActivations)
        {
            
            gameObject.SetActive(true);
            
        }
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(NextLevels);
    }

    public void SetTextActive(bool isActive)
    {
        isTextActive = isActive;
    }

}
