using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moving
{
    public class PlayerJump : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float jumpForce = 5.0f;
        public bool jumpControl;
        public float jumpIteration;
        public float jumpForSeconds = 2;
        public LayerMask Wall;

        public bool isGround;
        public float rayDistance = 0.6f;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            OnGround();
            if (Input.GetKey(KeyCode.Space))
            {
                if (isGround) { jumpControl = true; }
            }
            else { jumpControl = false; }

            if (jumpControl)
            {
                if (jumpIteration < jumpForSeconds)
                {
                    jumpIteration++;
                    //jumpIteration += Time.deltaTime;
                    rb.AddForce(Vector2.up * jumpForce / jumpIteration, ForceMode2D.Impulse);
                }
            }
            else
            {
                jumpIteration = 0;
            }
        }

        void OnGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, Wall);

            if (hit.collider != null)
            {
                isGround = true;

            }
            else
            {
                isGround = false;
            }
        }
    }
}