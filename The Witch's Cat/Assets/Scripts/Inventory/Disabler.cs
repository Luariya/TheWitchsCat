using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : Activatable
{
    [SerializeField] private GameObject objectToActivate;

    public override void Activate()
    {
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