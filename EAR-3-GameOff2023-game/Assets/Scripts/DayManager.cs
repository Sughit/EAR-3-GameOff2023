using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public static int dayNum = 1;
    public static int finishDayNum = 10;
    public int rent;
    public int bait;
    public Text dayText;
    public static int moneyNum;
    public int moneyMade;
    public Text moneyText;
    public Text moneyTotal;

    public GameObject dayMenu;
    public GameObject transition;
    
    public void CalculateMoney()
    {
        dayMenu.SetActive(true);

        dayText.text=$"Day: {dayNum}";
        dayNum++;

        moneyMade = RememberFish.numCodS * Random.Range(5,11) +
                   RememberFish.numCodB * Random.Range(15,26) +
                   RememberFish.numBarracudaS * Random.Range(10,16) +
                   RememberFish.numBarracudaB * Random.Range(20,31) +
                   RememberFish.numHerringS * Random.Range(5,11) +
                   RememberFish.numHerringB * Random.Range(15,26) +
                   RememberFish.numSalmonS * Random.Range(15,26) + 
                   RememberFish.numSalmonB * Random.Range(30,41) +
                   RememberFish.numTunaS * Random.Range(10,16) +
                   RememberFish.numTunaB * Random.Range(45,61);

        moneyText.text=$"Money made: {moneyMade}";
        moneyNum+=moneyMade;
        moneyNum-=rent;
        moneyNum-=bait;
        moneyTotal.text=$"Total: {moneyNum}";
        moneyMade=0;
    }

    public void NextDay()
    {
        if(!GoldFishScript.goldFish)
        {
            StartFishing.numBait=StartFishing.maxNumBait;
            StartCoroutine(Transition());
        }
        else
        {
            DialogueManager.finalDay=true;
            StartCoroutine(Transition());
        }
    }

    public void Upgrade()
    {
        StartCoroutine(TransitionToUpgrade());
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        dayMenu.SetActive(false);
        if(finishDayNum!=dayNum-1/*pt ca creste imediat dupa ce ai dat next day*/)
        {
            SceneManager.LoadScene("Dock");
        }
        else
        {
            SceneManager.LoadScene("DialogueStart");
        }
    }

    IEnumerator TransitionToUpgrade()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Upgrade");
    }
}
