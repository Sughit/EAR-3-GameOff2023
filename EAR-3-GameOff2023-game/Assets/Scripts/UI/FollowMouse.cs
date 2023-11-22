using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowMouse : MonoBehaviour
{
    public Image knife;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        knife = GetComponent<Image>();
        knife.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
