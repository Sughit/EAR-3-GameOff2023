using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBrain : MonoBehaviour
{
    public string fishType;
    public float speed;
    bool checkRotation=true;
    bool faceRight;
    bool faceLeft;

    void Update()
    {
        if(checkRotation)
        {
            GetCurrentRotation();
            checkRotation=false;
        }
        //in functie de rotatie decide ce directie va lua
        if(faceRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if(faceLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    void GetCurrentRotation()
    {
        if(transform.position.x>=0)
        {
            faceLeft=true;
        }
        else
        {
            faceRight=true;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
