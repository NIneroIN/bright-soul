using UnityEngine;

namespace Moving
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] bool right = true;
        private Rigidbody2D _rb;

        [Header("Climbing the stairs")]
        [SerializeField] LayerMask _steps;
        [SerializeField] bool onStep;
        [SerializeField] bool onStepsUp;
        [SerializeField] bool onStepsDown;
        [SerializeField] float StepsOffsetX;
        [SerializeField] float StepsOffsetY;

        [Header("Climbing the ladder")]
        [SerializeField] LayerMask _ladder;
        [SerializeField] bool onLadder;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ClimbStairs();
            ClimbLadder();
            DisabledPlatform();
        }

        private void FixedUpdate()
        {
            OnDirectionButtonPressed();
        }

        private static void DisabledPlatform()
        {
            if (Input.GetKey(KeyCode.S))
            {
                Physics2D.IgnoreLayerCollision(8, 9, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(8, 9, false);
            }
        }

        void ClimbLadder()
        {
            onLadder = Physics2D.OverlapCircle
            (
                new Vector2(transform.position.x, transform.position.y),
                10f,
                _ladder
            );

            if (onLadder) 
            {
                _rb.gravityScale = 0;
            }
            else if (!onStep)
            {
                _rb.gravityScale = 10;
            }
        }

        void ClimbStairs()
        {
            onStepsUp = Physics2D.Raycast
            (
                new Vector2(transform.position.x - StepsOffsetX * transform.localScale.x, transform.position.y + StepsOffsetY),
                Vector2.right * transform.localScale.x,
                20f,
                _steps
            );

            onStepsDown = Physics2D.Raycast
            (
                new Vector2(transform.position.x - StepsOffsetX * transform.localScale.x, transform.position.y + StepsOffsetY),
                new Vector2(-1 * transform.localScale.x, -1 * transform.localScale.y),
                20f,
                _steps
            );

            if ((onStepsDown & Input.GetKey(KeyCode.S)) || (onStepsUp & Input.GetKey(KeyCode.W)) || onStep)
            {
                Physics2D.IgnoreLayerCollision(8, 7, false);
                _rb.gravityScale = 0;
                onStep = true;
            }
            else
            {
                Physics2D.IgnoreLayerCollision(8, 7, true);
                _rb.gravityScale = 10;
            }
        }

        private void OnDirectionButtonPressed()
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (onStepsUp & onStep)
            {
                dir = new Vector2(dir.x, dir.x * transform.localScale.x);
                MovePlayer(dir, _speed);
            }
            else if (onStepsDown & onStep)
            {
                dir = new Vector2(dir.x, -dir.x * transform.localScale.x);
                MovePlayer(dir, _speed);
            }
            else if (onLadder)
            {
                MovePlayer(dir, _speed);
            }
            else
            {
                onStep = false;
                dir = new Vector2(dir.x, 0);
                MovePlayer(dir, _speed);
            }
        }

        private void MovePlayer(Vector2 dir, float speed)
        {
            Vector3 translation = new Vector3(dir.x, dir.y) * (speed * Time.fixedDeltaTime);
            transform.Translate(translation, Space.World);

            if (dir.x > 0 && !right || dir.x < 0 && right)
            {
                Flip();
            }
        }

        void Flip()
        {
            right = !right;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine
                (
                    new Vector2(transform.position.x - StepsOffsetX * transform.localScale.x, transform.position.y + StepsOffsetY),
                    new Vector2(transform.position.x - (StepsOffsetX - 10f) * transform.localScale.x, transform.position.y + StepsOffsetY)
                );
            Gizmos.DrawLine
                (
                    new Vector2(transform.position.x - StepsOffsetX * transform.localScale.x, transform.position.y + StepsOffsetY),
                    new Vector2(transform.position.x - (StepsOffsetX + 10f) * transform.localScale.x, transform.position.y + StepsOffsetY - 10f)
                );

            Gizmos.DrawLine
                (
                    new Vector2(transform.position.x, transform.position.y),
                    new Vector2(transform.position.x + 200f * transform.localScale.x, transform.position.y + 200f)
                );
        }
    }
}