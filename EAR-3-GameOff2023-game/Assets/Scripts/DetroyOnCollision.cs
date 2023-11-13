using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyOnCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
