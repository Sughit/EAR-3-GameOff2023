using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonStart_optional : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    void Start()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        StartCoroutine(button());
    }
    IEnumerator button()
    {
        yield return new WaitForSeconds(1.5f);
        button1.SetActive(true);
        button2.SetActive(true);
    }
    public void Yes()
    {
        SceneManager.LoadScene("Dock");
    }
    public void No()
    {
        Application.Quit();
    }
}

