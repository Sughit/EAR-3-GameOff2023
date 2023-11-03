using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScaling : MonoBehaviour
{
    public GameObject[] fishList;
    bool canCod;
    bool canBarracuda;
    bool canSalmon;
    bool canHerring;
    bool canTuna;

    public void ShowFish()
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
}
