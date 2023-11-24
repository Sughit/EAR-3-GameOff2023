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
        // pt scroll vertical
        // offSet.y -= Time.deltaTime/10f;
        // pt miscare cu carligul
        offSet.x = transform.position.x / transform.localScale.x / 7f;
        offSet.y = transform.position.y / transform.localScale.y / 7f;
        mat.mainTextureOffset = offSet;
    }
}
