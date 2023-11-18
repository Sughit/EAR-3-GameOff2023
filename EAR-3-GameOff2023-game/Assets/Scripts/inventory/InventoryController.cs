using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    private ItemGrid selectedItemGrid;
    public InventoryItem selectedItem;
    InventoryItem overlapItem;
    RectTransform rectTransform;
    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform canvasTransform;
    InventoryHighlight inventoryHighlight;
    InventoryItem itemToHighlight;
    Vector2Int oldPosition;
    public static bool codS, barracudaS, salmonS, herringS, tunaS;
    public static bool codB, barracudaB, salmonB, herringB, tunaB;
    string fish;
        openInventory openInv;
    public ItemGrid SelectedItemGrid
    { 
        get => selectedItemGrid; 
        set 
        {
            selectedItemGrid = value;
            inventoryHighlight.SetParent(value);
        }
    }

    void Awake()
    {
        inventoryHighlight = GetComponent<InventoryHighlight>();
        canvasTransform = GameObject.Find("Canvas").GetComponent<Transform>();
        openInv = GameObject.Find("Canvas").GetComponent<openInventory>();
    }
    void Update()
    {
        ItemIconDrag();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateRandomItem();
        }
        
        if(codS)
            CreateItem(0);
        if(barracudaS)
            CreateItem(1);
        if(salmonS)
            CreateItem(3);
        if(herringS)
            CreateItem(2);
        if(tunaS)
            CreateItem(4);
        if(codB)
            CreateItem(5);
        if(barracudaB)
            CreateItem(6);
        if(tunaB) 
            CreateItem(7);

        //totul codul trebuie sa fie scris neaparat sub if-ul asta
        if(selectedItemGrid == null)
        {
            inventoryHighlight.Show(false);
            return;
        }

        HandleHighlight();


        if(Input.GetMouseButtonDown(0))
        {
                LeftMouseButtonPress();
        }
    }


    void HandleHighlight()
    {
        Vector2Int positionOnGrid = GetTileGridPosition();

        if(oldPosition == positionOnGrid)
            return;

        oldPosition = positionOnGrid;

        if(selectedItem == null)
        {
            itemToHighlight = selectedItemGrid.GetItem(positionOnGrid.x, positionOnGrid.y);

            if(itemToHighlight != null)
            {
                inventoryHighlight.Show(true);
                inventoryHighlight.SetSize(itemToHighlight);
                inventoryHighlight.SetPosition(selectedItemGrid, itemToHighlight);
            }
            else
            {
                inventoryHighlight.Show(false);
            }
        }
        else
        {
            inventoryHighlight.Show(selectedItemGrid.BoundaryCheck(positionOnGrid.x, positionOnGrid.y, selectedItem.itemData.width, selectedItem.itemData.height));
            inventoryHighlight.SetSize(selectedItem);
            inventoryHighlight.SetPosition(selectedItemGrid, selectedItem, positionOnGrid.x, positionOnGrid.y);
        }
    }

    void LeftMouseButtonPress()
    {

            Vector2Int tileGridPosition = GetTileGridPosition();

            if (selectedItem == null)
            {
                PickUpItem(tileGridPosition);
            }
            else
            {
                PlaceItem(tileGridPosition);
            }
    }

    private Vector2Int GetTileGridPosition()
    {
        Vector2 position = Input.mousePosition;

            if (selectedItem != null)
            {
                position.x -= (selectedItem.itemData.width - 1) * ItemGrid.tileSizeWidth / 2;
                position.y -= (selectedItem.itemData.height - 1) * ItemGrid.tileSizeHeight / 2;
            }
            Vector2Int tileGridPosition = selectedItemGrid.GetTileGridPosition(Input.mousePosition);

            return tileGridPosition;
    }


    public void CreateItem(int fish)
    {
        openInventory.aux = true;
        codS = barracudaS = salmonS = herringS = tunaS = false;
        codB = barracudaB = salmonB = herringB = tunaB = false;
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);

        int selectedItemID = fish;
        inventoryItem.Set(items[selectedItemID]);
    }
    public void CreateRandomItem()
    {
        if(openInv.invOpen)
        {
            Debug.Log("randomItem");
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);

        int selectedItemID = UnityEngine.Random.Range(0, items.Count);
        inventoryItem.Set(items[selectedItemID]);
        }
    }
    void PlaceItem(Vector2Int tileGridPosition)
    {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        if (complete)
            {
                selectedItem = null;
                if(overlapItem != null)
                {
                    selectedItem = overlapItem;
                    selectedItem.transform.SetSiblingIndex(-999);
                    overlapItem = null;
                    rectTransform = selectedItem.GetComponent<RectTransform>();
                }
            }
    }
    void PickUpItem(Vector2Int tileGridPosition)
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        selectedItem.transform.SetSiblingIndex(-999);
        if(selectedItem != null)
        {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }
    void ItemIconDrag()
    {
        if(selectedItem != null)
        {
            rectTransform.position = Input.mousePosition;
        }
    }

    public void Delete()
    {
        if(selectedItem.itemData.name == "barracudaB")
                {RememberFish.numBarracudaB--;}
        if(selectedItem.itemData.name == "barracudaS")
                {RememberFish.numBarracudaS--;;}
        if(selectedItem.itemData.name == "codB")
                {RememberFish.numCodB--;}
        if(selectedItem.itemData.name == "codS")
                {RememberFish.numCodS--;}
        if(selectedItem.itemData.name == "herringS")
                {RememberFish.numHerringS--;  }  
        if(selectedItem.itemData.name == "salmonS")
                {RememberFish.numSalmonS--; }
        if(selectedItem.itemData.name == "tunaB")
                {RememberFish.numTunaB--; }
        if(selectedItem.itemData.name == "tunaS")
                {RememberFish.numTunaS--;}
            Destroy(selectedItem.gameObject);
    }
}
