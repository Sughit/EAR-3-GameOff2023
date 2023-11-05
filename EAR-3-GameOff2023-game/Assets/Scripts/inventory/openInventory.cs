using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInventory : MonoBehaviour
{
    public GameObject inv;
    bool invOpen;
    public static bool aux;
    void Start()
    {
        inv.SetActive(false);
        invOpen = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            aux = true;
            if(aux)
                OpenInv();


        if(invOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            inv.SetActive(false);
            invOpen = false;
        }
    }

    public void OpenInv()
    {
        aux = false;
        if(!invOpen)
            {
                inv.SetActive(true);
                invOpen = true;
            }
            else
            {
                inv.SetActive(false);
                invOpen = false;
            }
    }
}
