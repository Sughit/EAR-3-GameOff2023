using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Hook")
        {
            StartFishing.caughtFish=true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
