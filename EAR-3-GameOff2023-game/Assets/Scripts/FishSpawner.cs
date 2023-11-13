using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;
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
            Instantiate(fish,transform.position, Quaternion.identity);
            currentTime=Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }
        else
        {
            currentTime-=Time.deltaTime;
        }
    }
}
