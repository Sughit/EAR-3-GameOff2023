using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHighlight : MonoBehaviour
{
    [SerializeField] RectTransform highliter;
    void Awake()
    {
        highliter = GameObject.Find("Canvas/Inventory/highlighter").GetComponent<RectTransform>();
    }

    public void Show(bool b)
    {
        highliter.gameObject.SetActive(b);
    }

    public void SetSize(InventoryItem targetItem)
    {
        Vector2 size = new Vector2();
        size.x = targetItem.WIDTH * ItemGrid.tileSizeWidth;
        size.y = targetItem.HEIGHT * ItemGrid.tileSizeHeight;
        highliter.sizeDelta = size;
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem)
    {

        Vector2 pos = targetGrid.CalculatePositionOnGrid(targetItem, targetItem.onGridPositionX, targetItem.onGridPositionY);

        highliter.localPosition = pos;
    }

    public void SetParent(ItemGrid targetGrid)
    {
        if(targetGrid == null)
            return;
        highliter.SetParent(targetGrid.GetComponent<RectTransform>());
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem, int posX, int posY)
    {
        Vector2 pos = targetGrid.CalculatePositionOnGrid(targetItem, posX, posY);

        highliter.localPosition = pos;
    }
}
