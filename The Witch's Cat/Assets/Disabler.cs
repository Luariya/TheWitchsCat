using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : Activatable
{
    public override void Activate()
    {
        gameObject.SetActive(false);
    }
}
