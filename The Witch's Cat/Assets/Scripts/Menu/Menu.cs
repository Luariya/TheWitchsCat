using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Men�;
    public GameObject LevelSelect;
    public GameObject Credits;
    public GameObject Settings;

    public void QuitButton()
    {

        Debug.Log("Quit");
        Application.Quit();

    }

    public void StartButton()
    {

        SceneManager.LoadScene("TutorialScene");

    }

    public void LevelScreen()
    {

        LevelSelect.SetActive(true);
        Men�.SetActive(false);

    }
    public void Men�Screen()
    {

        LevelSelect.SetActive(false);
        Men�.SetActive(true);
        Credits.SetActive(false);
        Settings.SetActive(false);

    }

    public void CreditsScreen()
    {


        Men�.SetActive(false);
        Credits.SetActive(true);

    }

    public void SettingScreen()

    {
        Men�.SetActive(false);
        Settings.SetActive(true);

    }
}