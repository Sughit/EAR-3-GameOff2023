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
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big cod");
                InventoryController.codB = true;
                RememberFish.numCodS--;
                RememberFish.numCodB++;
            }
            else
            {
                InventoryController.codS = true;
                Debug.Log("Spawned small cod");
            }
        }
        //Spawn barracuda item
        else if(RememberFish.caughtBarracuda)
        {
            RememberFish.caughtBarracuda=false;
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big barracuda");
                InventoryController.barracudaB = true;
                RememberFish.numBarracudaS--;
                RememberFish.numBarracudaB++;
            }
            else
            {
                InventoryController.barracudaS = true;
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
            if(Random.Range(0,6)==3)
            {
                Debug.Log("Spawned big tuna");
                InventoryController.tunaB = true;
                RememberFish.numTunaS--;
                RememberFish.numTunaB++;
            }
            else
            {
                InventoryController.tunaS = true;
                Debug.Log("Spawned small tuna");
            }
        }
    }
}
