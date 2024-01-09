using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
   public void FirstLevel ()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void SecondLevel ()
    {
        SceneManager.LoadScene("Street");
    }
}
