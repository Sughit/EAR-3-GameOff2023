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
    public static List<GameObject> fishList = new List<GameObject>();

    public void AddFish(GameObject fish)
    {
        fishList.Add(fish);
    }

    public void SetNumOfFish()
    {
        foreach (var fish in fishList)
        {
            switch (fish.tag)
            {
                case "cod":
                numCod++;
                break;
                case "barracuda":
                numBarracuda++;
                break;
                case "herring":
                numHerring++;
                break;
                case "salmon":
                numSalmon++;
                break;
                case "tuna":
                numTuna++;
                break;
                default:
                Debug.Log("Peste neidentificat");
                break;
            }
        }
    }
}
