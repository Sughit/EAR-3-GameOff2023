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
            if(!StartFishing.caughtFish)
            {
                StartFishing.caughtFish=true;
                other.GetComponent<RememberFish>().AddFish(fishBrain.fishType);
                this.gameObject.SetActive(false);
            }
        }
    }

    public string GiveTag()
    {
        if(this.gameObject.tag=="cod")
            return "cod";
        else if(this.gameObject.tag=="barracuda")
            return "barracuda";
        else if(this.gameObject.tag=="herring")
            return "herring";
        else if(this.gameObject.tag=="salmon")
            return "salmon";
        else if(this.gameObject.tag=="tuna")
            return "tuna";
        else return null;
    }
}
