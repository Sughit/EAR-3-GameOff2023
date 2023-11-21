using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject meniu;
    openInventory openInv;
    public bool meniuDeschis;
    GameObject canvButoane;
    GameObject canvPeste;
    GameObject canvUpgrade;
    void Awake()
    {
        openInv = this.GetComponent<openInventory>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FishScaling") && !meniuDeschis) 
                {
                    canvPeste = GameObject.Find("CanvasPeste");
                }

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Upgrade") && !meniuDeschis) 
                {
                    canvUpgrade = GameObject.Find("CanvasUpgrade");
                }
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dock") && !meniuDeschis) 
                {
                    canvButoane = GameObject.Find("canvasButoane");
                }


        if (Input.GetKeyDown(KeyCode.Escape) && !meniuDeschis && SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("MainMenu"))
            {
                meniuDeschis = true;
                meniu.SetActive(true);
                
                Time.timeScale = 0;
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dock"))
                {
                    canvButoane.SetActive(false);
                    openInv.invOpen = false;
                    openInv.inv.SetActive(false);
                }

                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FishScaling")) 
                {
                    canvPeste.SetActive(false);
                }

                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Upgrade"))
                {
                    canvUpgrade.SetActive(false);
                }
            }
        else
            if (Input.GetKeyDown(KeyCode.Escape) && meniuDeschis && SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("MainMenu"))
            {
                meniuDeschis = false;
                meniu.SetActive(false);
                Time.timeScale = 1;
                
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dock"))
                {
                    canvButoane.SetActive(true);
                }

                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FishScaling")) 
                {
                    canvPeste.SetActive(true);
                }
                
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Upgrade"))
                {
                    canvUpgrade.SetActive(true);
                }
                
            }
    }
    public void Resume()
    {
        meniuDeschis = false;
        meniu.SetActive(false);
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dock"))
                {
                    canvButoane.SetActive(true);
                }

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FishScaling")) 
                {
                    canvPeste.SetActive(true);
                }

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Upgrade"))
            {
                canvUpgrade.SetActive(true);
            }
    }

    public void MainMenu()
    {
        meniuDeschis = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        meniu.SetActive(false);
    }
}
