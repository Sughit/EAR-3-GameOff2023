using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muzicaShop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject muzica;
    void Start()
    {
        DontDestroyOnLoad(muzica);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("FishScaling"))
            if(SceneManager.GetActiveScene () != SceneManager.GetSceneByName ("Upgrade"))
                DestroyImmediate(muzica);
    }
}
