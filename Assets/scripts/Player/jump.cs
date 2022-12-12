using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 startPos;

    public float _expiredTime;
    public float _duration;
    public float height;
    public AnimationCurve gravityFall;

    public Transform GroundCheck;
    public bool onGround = false;
    public float checkRadius = 0.4f;
    public LayerMask Ground;

    private bool isJump = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckingGround();
        PlayerJump();
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startPos = transform.position;
            isJump = true;
        }

        if (isJump)
        {
            _expiredTime += Time.deltaTime;

            if (_expiredTime > _duration || (onGround & _expiredTime > 0.1))
            {
                _rb.velocity = new Vector2(0, 0);
                transform.position = transform.position;
                _expiredTime = 0;
                isJump = false;
            }

            float progress = _expiredTime / _duration;
            transform.position = new Vector2(transform.position.x, startPos.y) + new Vector2(0, gravityFall.Evaluate(progress) * height);
        }
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
