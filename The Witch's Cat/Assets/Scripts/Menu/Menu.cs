using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Menü;
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
        Menü.SetActive(false);

    }
    public void MenüScreen()
    {

        LevelSelect.SetActive(false);
        Menü.SetActive(true);
        Credits.SetActive(false);
        Settings.SetActive(false);

    }

    public void CreditsScreen()
    {


        Menü.SetActive(false);
        Credits.SetActive(true);

    }

    public void SettingScreen()

    {
        Menü.SetActive(false);
        Settings.SetActive(true);

    }
}