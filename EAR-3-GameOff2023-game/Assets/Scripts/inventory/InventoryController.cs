using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid selectedItemGrid;

    void Update()
    {
        //totul codul trebuie sa fie scris neaparat sub if-ul asta
        if(selectedItemGrid==null) {return;}

        Debug.Log(selectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }
}
