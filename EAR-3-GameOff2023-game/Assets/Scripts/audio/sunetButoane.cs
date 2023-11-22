using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunetButoane : MonoBehaviour
{
    public GameObject sunet;
    public void Sunet()
    {
        Instantiate(sunet);
    }
}
