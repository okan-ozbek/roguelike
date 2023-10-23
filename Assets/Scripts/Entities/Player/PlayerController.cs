using System;
using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        public delegate void Default();
        
        public static event Default Dead;
        public static event Default Win;

        public float accelerationSpeed;
        public float decelerationSpeed;
        public Vector2 maxSpeed;

        private Vector2 _lastInput;
        private Vector3 _velocity;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            DEBUG_PLAYER_EVENTS();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Mathf.Abs(input.x) > 0.0f)
            {
                _velocity.x += accelerationSpeed;
                _velocity.x = Mathf.Clamp(_velocity.x, 0.0f, maxSpeed.x);

                _rigidbody.velocity = new Vector2(_velocity.x * input.x, _rigidbody.velocity.y);
                _lastInput.x = Mathf.Sign(input.x);
            }

            if (Mathf.Abs(input.y) > 0.0f)
            {
                _velocity.y += accelerationSpeed;
                _velocity.y = Mathf.Clamp(_velocity.y, 0.0f, maxSpeed.y);

                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _velocity.y * input.y);
                _lastInput.y = Mathf.Sign(input.y);
            }

            if (Mathf.Abs(input.x) == 0.0f)
            {
                _velocity.x -= accelerationSpeed;
                _velocity.x = Mathf.Clamp(_velocity.x, 0.0f, maxSpeed.x);

                _rigidbody.velocity = new Vector2(_velocity.x * _lastInput.x, _rigidbody.velocity.y);
            }

            if (Mathf.Abs(input.y) == 0.0f)
            {
                _velocity.y -= accelerationSpeed;
                _velocity.y = Mathf.Clamp(_velocity.y, 0.0f, maxSpeed.y);

                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _velocity.y * _lastInput.y);
            }
        }

        private void DEBUG_PLAYER_EVENTS()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Dead?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Win?.Invoke();
            }
        }
    }
}