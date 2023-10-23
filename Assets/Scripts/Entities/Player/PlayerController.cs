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
        
        public PlayerInput PlayerInput;
        public PlayerMovement PlayerMovement;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            PlayerInput = new PlayerInput();
            PlayerMovement = new PlayerMovement(this);
            
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            PlayerInput.Update();
            
            DEBUG_PLAYER_EVENTS();
        }

        private void FixedUpdate()
        {
            PlayerMovement.FixedUpdate();
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
                Dead?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Win?.Invoke();
            }
        }
        #endregion
    }
}