using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;
    public GameObject goldFish;
    public float minTimeToSpawn;
    public float maxTimeToSpawn;
    float timeToSpawn;
    float currentTime;

    void Start()
    {
        timeToSpawn=Random.Range(minTimeToSpawn, maxTimeToSpawn);
        currentTime=timeToSpawn;
    }

    void Update()
    {
        if(currentTime<=0)
        {
            if(DayManager.dayNum==10 && Random.Range(1,5)==2)
            {
                Instantiate(goldFish,transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(fish,transform.position, Quaternion.identity);
            }
            currentTime=Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }
        else
        {
            currentTime-=Time.deltaTime;
        }
    }
}
