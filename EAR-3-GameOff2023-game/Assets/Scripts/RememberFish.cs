using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberFish : MonoBehaviour
{
    public static List<GameObject> fishList = new List<GameObject>();

    public void AddFish(GameObject fish)
    {
        fishList.Add(fish);
    }
}
