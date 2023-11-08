using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeCaughtFish : MonoBehaviour
{
    public InventoryController inventoryController;
    public static SeeCaughtFish Instance;
    public void SpawnFishItem()
    {
        //Spawn cod item
        if(RememberFish.caughtCod)
        {
            RememberFish.caughtCod=false;
            InventoryController.codS = true;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big cod");
                RememberFish.numCodS--;
                RememberFish.numCodB++;
            }
            else
            {
                Debug.Log("Spawned small cod");
            }
        }
        //Spawn barracuda item
        else if(RememberFish.caughtBarracuda)
        {
            RememberFish.caughtBarracuda=false;
            InventoryController.barracudaS = true;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big barracuda");
                RememberFish.numBarracudaS--;
                RememberFish.numBarracudaB++;
            }
            else
            {
                Debug.Log("Spawned small barracuda");
            }
        }
        //Spawn herring item
        else if(RememberFish.caughtHerring)
        {
            RememberFish.caughtHerring=false;
            InventoryController.herringS = true;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big herring");
                RememberFish.numHerringS--;
                RememberFish.numHerringB++;
            }
            else
            {
                Debug.Log("Spawned small herring");
            }
        }
        //Spawn salmon item
        else if(RememberFish.caughtSalmon)
        {

            RememberFish.caughtSalmon=false;
            InventoryController.salmonS = true;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big salmon");
                RememberFish.numSalmonS--;
                RememberFish.numSalmonB++;
            }
            else
            {
                Debug.Log("Spawned small salmon");
            }
        }
        //Spawn tuna item
        else if(RememberFish.caughtTuna)
        {
            RememberFish.caughtTuna=false;
            InventoryController.tunaS = true;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big tuna");
                RememberFish.numTunaS--;
                RememberFish.numTunaB++;
            }
            else
            {
                Debug.Log("Spawned small tuna");
            }
        }
    }
}
