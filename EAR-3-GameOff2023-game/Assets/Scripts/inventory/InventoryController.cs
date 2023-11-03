using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid selectedItemGrid;
    InventoryItem selectedItem;

    void Update()
    {
        //totul codul trebuie sa fie scris neaparat sub if-ul asta
        if(selectedItemGrid==null) {return;}

        Debug.Log(selectedItemGrid.GetTileGridPosition(Input.mousePosition));

        if(Input.GetMouseButtonDown(0))
        {
            Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);

            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
            }
            else
            {
                selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y);
                selectedItem = null;
            }
        }
    }
}
