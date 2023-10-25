using Entities.Player.Factories;
using Entities.Player.States;
using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class PlayerContext : MonoBehaviour
    {
        #region Debugging delete this eventually
        public delegate void Default();
        public static event Default Dead;
        public static event Default Win;
        #endregion
        
        public PlayerInput PlayerInput;
        public PlayerBaseState State;
        public PlayerStateFactory Factory;
        
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            Factory = new PlayerStateFactory(this);
            State = Factory.Idle();

            PlayerInput = new PlayerInput();
            
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            PlayerInput.Update();
            State.Update();
            
            DEBUG_PLAYER_EVENTS();
        }

        private void FixedUpdate()
        {
            State.FixedUpdate();
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        #region Debugging delete this eventually.
        private void DEBUG_PLAYER_EVENTS()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Triggered death");
                Dead?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                print("Triggered win");
                Win?.Invoke();
            }
        }
        #endregion
    }
}