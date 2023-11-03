using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInventory : MonoBehaviour
{
    public GameObject inv;
    bool invOpen;
    void Start()
    {
        inv.SetActive(false);
        invOpen = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
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


        if(invOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            inv.SetActive(false);
            invOpen = false;
        }
    }
}
