using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour
{
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offSet = mat.mainTextureOffset;
        offSet.y -= Time.deltaTime/10f;
        mat.mainTextureOffset = offSet;
    }
}
