using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInvSize : MonoBehaviour
{
    public Canvas canvas;
    public static int width=4*32;
    public static int height=3*32;
    RectTransform invTrans;
    ItemGrid invGrid;

    void Update()
    {
        canvas=GameObject.Find("Canvas").GetComponent<Canvas>();
        invTrans = canvas.transform.Find("Inventory/grid").GetComponent<RectTransform>();
        if(invTrans!=null)
        {
            invTrans.sizeDelta = new Vector2(width, height);
        }
        invGrid = canvas.transform.Find("Inventory/grid").GetComponent<ItemGrid>();
        if(invGrid!=null)
        {
            invGrid.gridSizeWidth=width/32;
            invGrid.gridSizeHeight=height/32;
        }
    }
}
