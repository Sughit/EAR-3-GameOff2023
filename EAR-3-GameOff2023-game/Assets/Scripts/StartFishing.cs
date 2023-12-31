using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartFishing : MonoBehaviour
{
    public static bool startMiniGame;
    [Header("Stats")]
    public static float maxDepth = -50f;
    //asta se schimba cand dai upgrade
    public static int maxNumBait = 3;
    //nu asta
    public static int numBait = 3;
    [Header("Other")]
    public static bool caughtFish;
    public bool goUp;
    public float speedUp;
    public float speedDown;
    public GameObject hook;
    public GameObject transition;
    public SeeCaughtFish seeCaughtFish;
    [Header("UI")]
    public Text baitText;
    openInventory openInv;
    InventoryController invCont;

    // Start is called before the first frame update
    void Start()
    {
        invCont = GameObject.Find("Main Camera").GetComponent<InventoryController>();

        openInv = GameObject.Find("Canvas").GetComponent<openInventory>();
        if(SceneManager.GetActiveScene().name == "Dock")
            transition = GameObject.Find("Canvas2/transition");
        if(SceneManager.GetActiveScene().name == "FishingArea")
            transition = GameObject.Find("Canvas/transition");
        if(baitText!=null)
        {
            baitText.text=$"Num bait {numBait}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startMiniGame)
        {
            //daca nu ne ducem sus coboram
            if(!goUp)
            {
                //daca y-ul carligului este mai mare sau egal cu adancimea maxima atunci el ca cobori
                if(hook.transform.position.y >= maxDepth)
                {
                    hook.transform.Translate(Vector3.down * Time.deltaTime * speedDown);
                }
                else 
                {
                    goUp=true;
                }
            }
            //daca am ajuns la adancimea maxima urcam inapoi
            else if(hook.transform.position.y<=0)
            {
                hook.transform.Translate(Vector3.up * Time.deltaTime * speedUp);
            }
            else
            {
                StartCoroutine(Transition());
            }
            //daca nu am prins niciun peste atunci aratam un mesaj
            if(caughtFish)
            {
                goUp=true;
                Debug.Log("One fish caught");
            }
            else
            {
                Debug.Log("No fish caught");
            }
        }
    }

    public void StartFishingFunc()
    {
        if(numBait>0)
        {
            if (invCont.selectedItem == null)
            {
                Debug.Log("Start game");
                numBait--;
                if(baitText!=null)
                {
                    baitText.text=$"Num bait {numBait}";
                }
                openInventory.aux = false;
                openInv.inv.SetActive(false);
                caughtFish=false;
                StartCoroutine(Transition()); 
            }
        }  
        else
        {
            Debug.Log("not bait");
        }
    }

    public void CheckBait()
    {
        if(numBait<=0)
        {
            if (invCont.selectedItem == null)
            {
                openInv.inv.SetActive(false);
                StartCoroutine(Transition());
                SceneManager.LoadScene("FishScaling");
            }
        }
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        if(SceneManager.GetActiveScene().name == "Dock")
        {
            SceneManager.LoadScene("FishingArea");
            startMiniGame=true;
        }
        else if(SceneManager.GetActiveScene().name == "FishingArea")
        {
            SceneManager.LoadScene("Dock");
            openInv.invOpen = false;
            openInv.OpenInv();
            openInventory.aux=true;
            seeCaughtFish.SpawnFishItem();
            goUp=false;
            startMiniGame=false;
        }
    }
}
