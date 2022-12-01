using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private bool isFacingRight = true;
    public float horizontalAxis;

    public float jumpForce;
    public float increaseJumpForce;
    public int extraJump;
    public int countJump;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckingGround();
        // Прыжок

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

    }
    void FixedUpdate()
    {

        // Перемещение игрока по горизонтали
        horizontalAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);

        // Поворот персонажа
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }


    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.4f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
