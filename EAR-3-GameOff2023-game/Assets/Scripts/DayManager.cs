using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public static int dayNum = 1;
    public Text dayText;
    public static int moneyNum;
    public Text moneyText;

    public GameObject dayMenu;
    public GameObject transition;
    
    public void CalculateMoney()
    {
        dayMenu.SetActive(true);

        dayText.text=$"Day: {dayNum}";
        dayNum++;

        moneyNum = RememberFish.numCodS * Random.Range(5,11) +
                   RememberFish.numCodB * Random.Range(15,26) +
                   RememberFish.numBarracudaS * Random.Range(10,16) +
                   RememberFish.numBarracudaB * Random.Range(20,31) +
                   RememberFish.numHerringS * Random.Range(5,11) +
                   RememberFish.numHerringB * Random.Range(15,26) +
                   RememberFish.numSalmonS * Random.Range(15,26) + 
                   RememberFish.numSalmonB * Random.Range(30,41) +
                   RememberFish.numTunaS * Random.Range(10,16) +
                   RememberFish.numTunaB * Random.Range(45,61);

        moneyText.text=$"Money made: {moneyNum}";
    }

    public void NextDay()
    {
        StartFishing.numBait=StartFishing.maxNumBait;
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        dayMenu.SetActive(false);
        SceneManager.LoadScene("Dock");
    }
}
