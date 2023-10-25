using Entities.Player.Factories;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Entities.Player.States
{
    public sealed class PlayerMoveState : PlayerBaseState
    {
        public PlayerMoveState(PlayerContext context, PlayerStateFactory factory) : base(context, factory)
        {
        }

        private const float Acceleration = 18.0f;
        private const float Deceleration = 25.0f;
        private const float MaxSpeed = 7.0f;
        
        private Vector2 _velocity;
        
        protected override void OnStart()
        {
            // Set animation to move animation
        }

        protected override void OnFixedUpdate()
        {
            Debug.Log(_velocity);
            
            Accelerate();
            Decelerate();
        }

        protected override void UpdateState()
        {
            if (Context.PlayerInput.InputDirection == Vector2.zero && _velocity == Vector2.zero)
            {
                SwitchState(Factory.Idle());
            }
        }

        private void Accelerate()
        {
            if (Context.PlayerInput.InputDirection == Vector2.zero)
            {
                return;
            }
            
            SuddenMovementChange();
                
            _velocity += Vector2.one * Acceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, MaxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, MaxSpeed)
            );

            Context.SetVelocity(_velocity * Context.PlayerInput.InputDirection);
        }

        private void Decelerate()
        {
            if (Context.PlayerInput.InputDirection != Vector2.zero)
            {
                return;
            }

            _velocity -= Vector2.one * Deceleration * Time.deltaTime;
            _velocity = new Vector2(
                Mathf.Clamp(_velocity.x, 0.0f, MaxSpeed), 
                Mathf.Clamp(_velocity.y, 0.0f, MaxSpeed)
            );

            Context.SetVelocity(_velocity * Context.PlayerInput.LastInputDirection);
        }

        private void SuddenMovementChange()
        {
            if (Context.PlayerInput.InputDirection != Context.PlayerInput.LastInputDirection)
            {
                _velocity *= 0.8f;
            }
        }
    }
}