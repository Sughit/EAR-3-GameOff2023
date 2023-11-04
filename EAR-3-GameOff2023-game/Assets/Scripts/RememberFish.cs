using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberFish : MonoBehaviour
{
    public static int numCod;
    public static int numBarracuda;
    public static int numSalmon;
    public static int numHerring;
    public static int numTuna;

    public string[] fishList= new string[StartFishing.maxNumBait];
    public int index;

    public static bool caughtCod;
    public static bool caughtBarracuda;
    public static bool caughtSalmon;
    public static bool caughtHerring;
    public static bool caughtTuna;

    public void AddFish(string fish)
    {
        fishList[index]=fish;
        SetNumOfFish(fish);
    }

    public void SetNumOfFish(string fish)
    {
            switch (fish)
            {
                case "cod":
                caughtCod=true;
                numCod++;
                break;
                case "barracuda":
                caughtBarracuda=true;
                numBarracuda++;
                break;
                case "herring":
                caughtHerring=true;
                numHerring++;
                break;
                case "salmon":
                caughtSalmon=true;
                numSalmon++;
                break;
                case "tuna":
                caughtTuna=true;
                numTuna++;
                break;
                default:
                Debug.Log("Peste neidentificat");
                break;
            }
            index++;
    }
}
