using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;


    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void SettingsMenuBack()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("DialogueStart");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
