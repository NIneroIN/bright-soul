using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForSmallBox : MonoBehaviour
{
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.4f;
    public LayerMask Ground;

    public bool isBox;
    public Transform BoxCheck;
    public LayerMask Box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckingGround();
        CheckingBox();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBox && onGround)
        {
            transform.position = BoxCheck.position;
        }
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

    void CheckingBox()
    {
        isBox = Physics2D.Raycast(BoxCheck.position, new Vector2(0, -1) * 20f, checkRadius, Box);
    }
}
