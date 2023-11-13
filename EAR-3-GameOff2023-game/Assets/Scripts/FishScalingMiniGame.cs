using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScalingMiniGame : MonoBehaviour
{
    public static List<GameObject> scales = new List<GameObject>();
    public FishScaling fishScaling;

    void Update()
    {
        foreach(var scale in scales)
        {
            if(scale!=null) return;
            else fishScaling.ScaleFish();
        }
    }
}
