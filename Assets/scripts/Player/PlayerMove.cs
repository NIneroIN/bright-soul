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
        [SerializeField] bool onStepsUp;
        [SerializeField] bool onStepsDown;
        [SerializeField] float StepsOffsetX;
        [SerializeField] float StepsOffsetY;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
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

            if (!onStepsDown & !onStepsUp)
            {
                _rb.gravityScale = 10;
            }
            else
            {
                _rb.gravityScale = 0;
            }
        }

        private void OnEnable()
        {
            InputHandler.DirectionButtonPressed += OnDirectionButtonPressed;
        }

        private void OnDirectionButtonPressed(Vector2 dir)
        {
            if (onStepsUp)
            {
                dir = new Vector2(dir.x, 1);
                MovePlayer(dir, _speed);
                
            }
            else if (onStepsDown)
            {
                dir = new Vector2(dir.x, -1);
                MovePlayer(dir, _speed);
            }
            else
            {
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

        private void OnDisable()
        {
            InputHandler.DirectionButtonPressed -= OnDirectionButtonPressed;
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
        }
    }
}