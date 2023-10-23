using UnityEngine;

namespace Entities.Player
{
    public class PlayerMovement
    {
        private const float Acceleration = 18.0f;
        private const float Deceleration = 25.0f;
        private const float MaxSpeed = 7.0f;

        private Vector2 _velocity;

        private readonly PlayerController _controller;
        
        public PlayerMovement(PlayerController controller)
        {
            _controller = controller;
        }
        
        public void FixedUpdate()
        {
            Accelerate();
            Decelerate();
        }

        private void Accelerate()
        {
            if (_controller.PlayerInput.InputDirection == Vector2.zero)
            {
                return;
            }
            
            SuddenMovementChange();
                
            _velocity += Vector2.one * Acceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, MaxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, MaxSpeed)
            );

            _controller.SetVelocity(_velocity * _controller.PlayerInput.InputDirection);
        }

        private void Decelerate()
        {
            if (_controller.PlayerInput.InputDirection != Vector2.zero)
            {
                return;
            }

            _velocity -= Vector2.one * Deceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, MaxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, MaxSpeed)
            );

            _controller.SetVelocity(_velocity * _controller.PlayerInput.LastInputDirection);
        }

        private void SuddenMovementChange()
        {
            if (_controller.PlayerInput.InputDirection != _controller.PlayerInput.LastInputDirection)
            {
                _velocity *= 0.8f;
            }
        }
    }
}