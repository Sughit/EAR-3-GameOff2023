using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public static int dayNum;
    public Text dayText;
    public static int moneyNum;
    public Text moneyText;
    public GameObject dayMenu;
    
    public void CalculateMoney(string fishName)
    {
        switch (fishName)
        {
            case "cod":
            moneyNum+=Random.Range(10,16);
            break;

            case "barracuda":
            moneyNum+=Random.Range(20,26);
            break;

            case "herring":
            moneyNum+=Random.Range(13,18);
            break;

            case "salmom":
            moneyNum+=Random.Range(25,31);
            break;

            case "tuna":
            moneyNum+=Random.Range(5,11);
            break;

            default:
            Debug.Log("Fish not existing");
            break;
        }
    }
}
