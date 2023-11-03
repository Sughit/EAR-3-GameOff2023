using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;
    public float timeToSpawn;
    float currentTime;

    void Start()
    {
        currentTime=timeToSpawn;
    }

    void Update()
    {
        if(currentTime<=0)
        {
            Instantiate(fish,transform.position, Quaternion.identity);
            currentTime=timeToSpawn;
        }
        else
        {
            currentTime-=Time.deltaTime;
        }
    }
}
