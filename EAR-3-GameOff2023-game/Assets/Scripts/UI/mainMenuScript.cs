using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject transition;

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
        StartCoroutine(TransitionGame());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator TransitionGame()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("DialogueStart");
    }
}
