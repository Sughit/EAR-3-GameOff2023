using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishScaling : MonoBehaviour
{
    public GameObject transition;
    [Space]
    public GameObject[] fishList;
    bool canCod;
    bool canBarracuda;
    bool canSalmon;
    bool canHerring;
    bool canTuna;

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
        
    }

    public void ToDock()
    {
        if(!canCod && !canBarracuda && !canHerring && !canSalmon && !canTuna)
        {
            StartCoroutine(Transition());
        }
    }

    public void SeeWhatFishToShow()
    {
        if(RememberFish.numCod>=1)
            canCod=true;
        if(RememberFish.numBarracuda>=1)
            canBarracuda=true;
        if(RememberFish.numSalmon>=1)
            canSalmon=true;
        if(RememberFish.numHerring>=1)
            canHerring=true;
        if(RememberFish.numTuna>=1)
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
                break;
            }
            else if(canBarracuda)
            {
                fishList[1].SetActive(true);
                canBarracuda=false;
                break;
            }
            else if(canSalmon)
            {
                fishList[2].SetActive(true);
                canSalmon=false;
                break;
            }
            else if(canHerring)
            {
                fishList[3].SetActive(true);
                canHerring=false;
                break;
            }
            else if(canTuna)
            {
                fishList[4].SetActive(true);
                canTuna=false;
                break;
            }
        }
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Dock");
    }
}
