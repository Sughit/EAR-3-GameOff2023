using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberFish : MonoBehaviour
{
    public static int numCodS;
    public static int numBarracudaS;
    public static int numSalmonS;
    public static int numHerringS;
    public static int numTunaS;
    public static int numGoldFishS;

    public static int numCodB;
    public static int numBarracudaB;
    public static int numSalmonB;
    public static int numHerringB;
    public static int numTunaB;
    public static int numGoldFishB;

    public string[] fishList= new string[StartFishing.maxNumBait];
    public int index;

    public static bool caughtCod;
    public static bool caughtBarracuda;
    public static bool caughtSalmon;
    public static bool caughtHerring;
    public static bool caughtTuna;
    public static bool caughtGoldFish;

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
                numCodS++;
                break;
                case "barracuda":
                caughtBarracuda=true;
                numBarracudaS++;
                break;
                case "herring":
                caughtHerring=true;
                numHerringS++;
                break;
                case "salmon":
                caughtSalmon=true;
                numSalmonS++;
                break;
                case "tuna":
                caughtTuna=true;
                numTunaS++;
                break;
                case "goldFish":
                caughtGoldFish=true;
                numGoldFishS++;
                break;
                default:
                Debug.Log("Peste neidentificat");
                break;
            }
            index++;
    }
}
