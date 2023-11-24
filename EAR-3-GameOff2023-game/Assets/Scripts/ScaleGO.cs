using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGO : MonoBehaviour
{
    public GameObject sunet1;
    public GameObject sunet2;
    public GameObject sunet3;
    public GameObject sunet4;
    public GameObject sunet5;
    public GameObject sunet6;
    public GameObject sunet7;
    public GameObject sunet8;
    public GameObject sunet9;
    int scale;



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="knife")
        {
            scale = Random.Range(1,9);
            switch (scale)
            {
                case 1: Instantiate(sunet1); break;
                case 2: Instantiate(sunet2); break;
                case 3: Instantiate(sunet3); break;
                case 4: Instantiate(sunet4); break;
                case 5: Instantiate(sunet5); break;
                case 6: Instantiate(sunet6); break;
                case 7: Instantiate(sunet7); break;
                case 8: Instantiate(sunet8); break;
                case 9: Instantiate(sunet9); break;
                default: break;
            }
            //fa animatie
            Debug.Log("Cutit");
            FishScalingMiniGame.currentNumScale--;
            Destroy(this.gameObject);
        }
    }
}
