using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject PauseMen�;
    public GameObject Memory;

    public void SettingsPausemenuBack()
    {
        PauseMen�.SetActive(true);
        Settings.SetActive(false);

    }
    public void SettingsPausemenuStart()
    {
        PauseMen�.SetActive(false);
        Settings.SetActive(true);
    }
    public void Men�Screen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Memories()
    {
        PauseMen�.SetActive(false);
        Memory.SetActive(true);
    }
}
