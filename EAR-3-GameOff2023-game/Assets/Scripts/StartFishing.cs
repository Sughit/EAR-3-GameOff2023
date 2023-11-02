using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFishing : MonoBehaviour
{
    public bool startMiniGame;
    [Header("Stats")]
    public float maxDepth;
    [Header("Other")]
    public static bool caughtFish;
    public bool goUp;
    public float speedUp;
    public float speedDown;
    public GameObject cam;
    public GameObject hook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startMiniGame)
        {
            caughtFish=false;
            //daca nu ne ducem sus coboram
            if(!goUp)
            {
                //daca y-ul carligului este mai mare sau egal cu adancimea maxima atunci el ca cobori
                if(hook.transform.position.y >= maxDepth)
                {
                    hook.transform.Translate(Vector3.down * Time.deltaTime * speedDown);
                    cam.transform.Translate(Vector3.down * Time.deltaTime * speedDown);
                }
                else 
                {
                    goUp=true;
                }
            }
            //daca am ajuns la adancimea maxima urcam inapoi
            else
            {
                hook.transform.Translate(Vector3.up * Time.deltaTime * speedUp);
                cam.transform.Translate(Vector3.up * Time.deltaTime * speedUp);
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
        //camera se concentreaza pe carlig (faci tu cumva)

        startMiniGame=true;
    }
}
