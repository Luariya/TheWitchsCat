using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Color newColor = Color.red; // Set the new color in the Inspector

    public void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

    public void PlayAnimation ()
    {

    }

    public void ChangeSprite ()
    {

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
