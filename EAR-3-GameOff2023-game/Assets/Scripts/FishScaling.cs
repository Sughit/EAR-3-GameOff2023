using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishScaling : MonoBehaviour
{
    public GameObject transition;
    public DayManager dayManager;
    [Space]
    public GameObject[] fishList;
    bool canCod;
    bool canBarracuda;
    bool canSalmon;
    bool canHerring;
    bool canTuna;
    GameObject canvas;
    GameObject camera;

    public void Canvas()
    {
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
        camera = GameObject.Find("Main Camera");
        canvas = GameObject.Find("Canvas");
        Destroy(canvas.gameObject);
        Destroy(camera.gameObject);
    }

    void Start()
    {
        SeeWhatFishToShow();
        ScaleFish();
    }

    public void NextFish()
    {
        foreach(var fish in fishList)
        {
            if(fish.gameObject.activeSelf)
                fish.gameObject.SetActive(false);
        }
        ScaleFish();
    }

    public void EndDay()
    {
        if(!canCod && !canBarracuda && !canHerring && !canSalmon && !canTuna)
        {
            StartCoroutine(Transition());
        }
        else
        {
            Debug.Log("There are fish to be scaled");
        }
    }

    public void SeeWhatFishToShow()
    {
        if(RememberFish.numCodS>=1 || RememberFish.numCodB>=1)
            canCod=true;
        if(RememberFish.numBarracudaS>=1 || RememberFish.numBarracudaB>=1)
            canBarracuda=true;
        if(RememberFish.numSalmonS>=1 || RememberFish.numSalmonB>=1)
            canSalmon=true;
        if(RememberFish.numHerringS>=1 || RememberFish.numHerringB>=1)
            canHerring=true;
        if(RememberFish.numTunaS>=1 || RememberFish.numTunaB>=1)
            canTuna=true;
    }

    public void ScaleFish()
    {
        for(int i=0; i<fishList.Length;i++)
        {
            if(canCod)
            {
                fishList[0].SetActive(true);
                canCod=false;
                FishScalingMiniGame.registerFish=true;
                break;
            }
            else if(canBarracuda)
            {
                fishList[1].SetActive(true);
                canBarracuda=false;
                FishScalingMiniGame.registerFish=true;
                break;
            }
            else if(canSalmon)
            {
                fishList[2].SetActive(true);
                canSalmon=false;
                FishScalingMiniGame.registerFish=true;
                break;
            }
            else if(canHerring)
            {
                fishList[3].SetActive(true);
                canHerring=false;
                FishScalingMiniGame.registerFish=true;
                break;
            }
            else if(canTuna)
            {
                fishList[4].SetActive(true);
                canTuna=false;
                FishScalingMiniGame.registerFish=true;
                break;
            }
        }
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        dayManager.CalculateMoney();
    }
}
