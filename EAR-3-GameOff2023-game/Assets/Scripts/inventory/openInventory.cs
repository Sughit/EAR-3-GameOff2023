using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openInventory : MonoBehaviour
{
    public GameObject inv;
    public bool invOpen;
    public static bool aux;
    public static openInventory Instance;
    public GameObject cam;
    public GameObject sound;

    public void Awake()
    {
        inv.SetActive(true);
        aux = true;
        if(Instance)
        {
                DestroyImmediate(gameObject);
                DestroyImmediate(cam);
        }
            else
            {
                DontDestroyOnLoad(gameObject);
                DontDestroyOnLoad(cam);
                Instance = this;
            }
    }

    void Start()
    {
        inv.SetActive(false);
        invOpen = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dock")) 
                {
                    Instantiate(sound);
                    aux = true;
                }
            if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FishScaling") || SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("DialogueStart"))
                aux = false;
            if(aux)
                OpenInv();


        // if(invOpen && Input.GetKeyDown(KeyCode.Escape))
        // {
        //     inv.SetActive(false);
        //     invOpen = false;
        // }
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
