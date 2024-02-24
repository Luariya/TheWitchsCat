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
    public void ThirdLevel()
    {
        SceneManager.LoadScene("CityCentre");
    }

    public void FourthLevel()
    {
        SceneManager.LoadScene("Forest");
    }

    public void FifthLevel()
    {
        SceneManager.LoadScene("WitchHut");
    }
}
