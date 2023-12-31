using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    //A SE MODIFICA IN FUNCTIE DE MARIMEA IMAGINII  
    public const float tileSizeWidth=96;
    public const float tileSizeHeight=96;

    InventoryItem[,] inventoryItemSlot;

    RectTransform rectTransform;
    [SerializeField] public int gridSizeWidth = 20;
    [SerializeField] public int gridSizeHeight = 10;
    [SerializeField] GameObject inventoryItemPrefab;

    void Start()
    {
        rectTransform=GetComponent<RectTransform>();
        Init(gridSizeWidth , gridSizeHeight);

        InventoryItem inventoryItem = Instantiate (inventoryItemPrefab).GetComponent<InventoryItem>();
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        InventoryItem toReturn = inventoryItemSlot[x, y];

        if (toReturn == null)
        {
            return null;
        }


        CleanGridReference(toReturn);

        return toReturn;
    }

    void CleanGridReference(InventoryItem item)
    {
        for (int ix = 0; ix < item.WIDTH; ix++)
        {
            for (int iy = 0; iy < item.HEIGHT; iy++)
            {
                inventoryItemSlot[item.onGridPositionX + ix, item.onGridPositionY + iy] = null;
            }
        }
    }

    void Init(int width, int height)
    {
        inventoryItemSlot = new InventoryItem[width, height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
    }

    internal InventoryItem GetItem(int x, int y)
    {
        return inventoryItemSlot[x, y];
    }

    Vector2 positionOnTheGrid=new Vector2();
    Vector2Int tileGridPosition=new Vector2Int();

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);

        return tileGridPosition;
    }

    public bool PlaceItem(InventoryItem inventoryItem, int posX, int posY, ref InventoryItem overlapItem)
    {

        if (BoundaryCheck(posX, posY, inventoryItem.WIDTH, inventoryItem.HEIGHT) == false)
            return false;


        if(OverlapCheck(posX, posY, inventoryItem.WIDTH, inventoryItem.HEIGHT, ref overlapItem) == false)
        {
            overlapItem = null;
            return false;
        }

        if(overlapItem !=null)
            CleanGridReference(overlapItem);


        RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);



        for (int x = 0; x < inventoryItem.WIDTH; x++)
        {
            for(int y = 0; y < inventoryItem.HEIGHT; y++)
            {
                inventoryItemSlot[posX + x, posY + y] = inventoryItem;
            }
        }

        inventoryItem.onGridPositionX = posX;
        inventoryItem.onGridPositionY = posY;

        inventoryItemSlot[posX, posY] = inventoryItem;

        Vector2 position = CalculatePositionOnGrid(inventoryItem, posX, posY);

        rectTransform.localPosition = position;

        return true;
        
    }


    public Vector2 CalculatePositionOnGrid(InventoryItem inventoryItem, int posX, int posY)
    {
        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth + tileSizeWidth * inventoryItem.WIDTH / 2;
        position.y = -(posY * tileSizeHeight + tileSizeHeight * inventoryItem.HEIGHT / 2);

        return position;
    }
    private bool OverlapCheck(int posX, int posY, int width, int height, ref InventoryItem overlapItem)
    {

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(inventoryItemSlot[posX + x, posY + y] != null)
                    if (overlapItem == null)
                        overlapItem = inventoryItemSlot[posX + x, posY + y];
                    else
                        if(overlapItem != inventoryItemSlot[posX + x, posY + y])
                            return false;
            }
        }
        return true;
    }

    bool PositionCheck(int posX, int posY)
    {
        if(posX < 0 || posY < 0)
            return false;

        if(posX >= gridSizeWidth || posY >= gridSizeHeight)
            return false;

        return true;
    }

    public bool BoundaryCheck(int posX, int posY, int width, int height)
    {
        if (PositionCheck(posX, posY) == false)
            return false;
        
        posX += width-1;
        posY += height-1;

        if(PositionCheck(posX, posY) == false)
            return false;

        return true;
    }
}
