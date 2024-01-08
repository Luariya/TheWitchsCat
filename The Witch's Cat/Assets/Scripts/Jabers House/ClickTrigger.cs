using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickTrigger : MonoBehaviour
{
    [SerializeField]
    private bool destroyAfterTriggered = false;
    [SerializeField]
    private bool isActivated = true;
    public string NextLevels;

    [SerializeField]
    private UnityEvent OnTrigger;

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0) && isActivated)
        {
            // Raycast to determine if the click hits this object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // If the click hits this object, trigger the event
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnTrigger?.Invoke();

                if (destroyAfterTriggered)
                    Destroy(gameObject);
            }
        }
    }

    public void ActivateTrigger()
    {
        isActivated = true;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(NextLevels);
    }
}
