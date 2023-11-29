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
    public GameObject transition;
    bool dock;
    bool menu;
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


        if (Input.GetKeyDown(KeyCode.Escape) && !meniuDeschis && SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("MainMenu") && SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("DialogueStart"))
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

    public void TotalRestart()
    {
        //resetare toate variabilele
        RememberFish.numCodS = 0;
        RememberFish.numBarracudaS = 0;
        RememberFish.numSalmonS = 0;
        RememberFish.numHerringS = 0;
        RememberFish.numTunaS = 0;
        RememberFish.numCodB = 0;
        RememberFish.numBarracudaB = 0;
        RememberFish.numSalmonB = 0;
        RememberFish.numHerringB = 0;
        RememberFish.numTunaB = 0;

        upgradeManager.rodI=false;
        upgradeManager.rodII=false;
        upgradeManager.rodMax=false;
        upgradeManager.baitI=false;
        upgradeManager.baitII=false;
        upgradeManager.baitMax=false;
        upgradeManager.invI=false;
        upgradeManager.invII=false;
        upgradeManager.invMax=false;

        DayManager.dayNum=1;
        DayManager.moneyNum=0;

        StartFishing.maxDepth=-50f;
        StartFishing.maxNumBait=3;
        StartFishing.numBait=3;

        upgradeManager.rodPrice=20;
        upgradeManager.baitPrice=25;
        upgradeManager.inventoryPrice=30;

        Time.timeScale = 1;
        StartCoroutine(TransitionDock());
        //StartCoroutine(TransitionDock());

        GameObject camera = GameObject.Find("Main Camera");
        GameObject canvas = GameObject.Find("Canvas");

        Destroy(canvas.gameObject);
        Destroy(camera.gameObject);
        
        SceneManager.LoadScene("Dock");
    }

    public void MainMenu()
    {
        meniuDeschis = false;
        Time.timeScale = 1;
        StartCoroutine(TransitionMenu());
        meniu.SetActive(false);
    }

    IEnumerator TransitionMenu()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator TransitionDock()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Dock");
    }

}
