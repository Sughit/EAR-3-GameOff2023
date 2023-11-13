using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGO : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="knife")
        {
            //fa animatie
            Destroy(this.gameObject);
        }
    }
}
