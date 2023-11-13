using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScalingMiniGame : MonoBehaviour
{
    public List<GameObject> scales = new List<GameObject>();
    public GameObject[] fishList;
    public FishScaling fishScaling;
    public static bool registerFish=true;

    void Update()
    {
        foreach(var fish in fishList)
        {
            if(fish.activeSelf)
            {
                if(registerFish)
                {
                    for(int i=0;i<fish.GetComponent<FishBody>().localScale.Length;i++)
                    {
                        scales.Add(fish.GetComponent<FishBody>().localScale[i]);
                    }
                    registerFish=false;
                }
                foreach(var scale in scales)
                {
                    if(scale!=null) return;
                    else fishScaling.ScaleFish();
                }
            }
        }
    }
}
