using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour
{
    private float horizontal;
    private Vector2 moveDirection;
    private float speed = 8f;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if(!StartFishing.startMiniGame)
        {
            speed=0;
        }
        else
        {
            speed=8f;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(horizontal , 0);
        moveDirection.Normalize();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
}
