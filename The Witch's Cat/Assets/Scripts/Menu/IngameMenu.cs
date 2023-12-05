using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject PauseMenü;
    public GameObject Memory;

    public void SettingsPausemenuBack()
    {
        PauseMenü.SetActive(true);
        Settings.SetActive(false);

    }
    public void SettingsPausemenuStart()
    {
        PauseMenü.SetActive(false);
        Settings.SetActive(true);
    }
    public void MenüScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Memories()
    {
        PauseMenü.SetActive(false);
        Memory.SetActive(true);
    }
}
