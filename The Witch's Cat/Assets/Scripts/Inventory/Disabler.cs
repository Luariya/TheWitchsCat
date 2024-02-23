using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Disabler : Activatable
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private int neededDeactivations = 1;
    private int currentDeactivations = 0;

    public UnityEvent OnDisabled;


    public override void Activate()
    {
        currentDeactivations++;

        if (currentDeactivations >= neededDeactivations)
        {
            OnDisabled?.Invoke();

            gameObject.SetActive(false);

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Object to activate is not set in Disabler script.");
            }
        }
    }
}