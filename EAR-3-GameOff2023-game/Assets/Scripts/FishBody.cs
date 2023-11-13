using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBody : MonoBehaviour
{
    public GameObject[] localScale;
    FishScalingMiniGame fishScale;

    // void Awake()
    // {
    //     fishScale=GameObject.Find("scalingManager").GetComponent<FishScalingMiniGame>();
    //     fishScale.scales = new List<GameObject>();
    //     for(int i=0;i<localScale.Length;i++)
    //     {
    //         fishScale.scales[i]=localScale[i];
    //     }
    // }
}
