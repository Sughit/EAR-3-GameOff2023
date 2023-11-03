using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    FishBrain fishBrain;

    void Start()
    {
        fishBrain=this.gameObject.GetComponent<FishBrain>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name=="hook")
        {
            StartFishing.caughtFish=true;
            other.GetComponent<RememberFish>().AddFish(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
