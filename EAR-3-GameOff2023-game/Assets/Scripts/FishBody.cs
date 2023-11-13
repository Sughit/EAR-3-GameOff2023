using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBody : MonoBehaviour
{
    public GameObject[] localScale;

    void Awake()
    {
        FishScalingMiniGame.scales = new List<GameObject>();
        for(int i=0;i<localScale.Length;i++)
        {
            FishScalingMiniGame.scales[i]=localScale[i];
        }
    }
}
