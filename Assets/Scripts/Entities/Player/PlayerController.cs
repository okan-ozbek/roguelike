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

        public float acceleration;
        public float deceleration;
        public float maxSpeed;
        
        private Vector2 _input;
        private Vector2 _lastInput;
        private Vector2 _velocity;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            
            DEBUG_PLAYER_EVENTS();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Accelerate();
            Decelerate();
        }

        private void Accelerate()
        {
            if (_input == Vector2.zero)
            {
                return;
            }
            
            SuddenMovementChange();
                
            _velocity += Vector2.one * acceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, maxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, maxSpeed)
            );
                
            _lastInput = _input;
                
            _rigidbody.velocity = _velocity * _input;
        }

        private void Decelerate()
        {
            if (_input != Vector2.zero)
            {
                return;
            }

            _velocity -= Vector2.one * deceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, maxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, maxSpeed)
            );

            _rigidbody.velocity = _velocity * _lastInput;
        }

        private void SuddenMovementChange()
        {
            if (_input != _lastInput)
            {
                _velocity *= 0.8f;
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