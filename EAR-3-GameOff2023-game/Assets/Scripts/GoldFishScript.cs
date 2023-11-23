using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFishScript : MonoBehaviour
{
    public static bool goldFish;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Hook")
        {
            goldFish=true;
        }
    }
}
