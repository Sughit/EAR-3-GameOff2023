using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFishing : MonoBehaviour
{
    public static bool startMiniGame;
    [Header("Stats")]
    public float maxDepth;
    [Header("Other")]
    public static bool caughtFish;
    public bool goUp;
    public float speedUp;
    public float speedDown;
    public GameObject hook;
    public GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Start game");
        caughtFish=false;
        StartCoroutine(Transition());   
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
            goUp=false;
            startMiniGame=false;
        }
    }
}
