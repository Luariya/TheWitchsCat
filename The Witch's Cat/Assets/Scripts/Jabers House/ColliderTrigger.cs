using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField]
    private bool destroyAfterTriggered = false;
    [SerializeField]
    private bool isActivated = true;

    [SerializeField]
    private UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isActivated)
        {

            OnTrigger?.Invoke();

            if (destroyAfterTriggered)
                Destroy(gameObject);
        }
    }

    public void ActivateTrigger()
    {
        isActivated = true;
    }
}
