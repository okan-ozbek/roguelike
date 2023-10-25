using UnityEngine; 

namespace Entities.Player
{
    public sealed class PlayerInput
    {
        public Vector2 InputDirection { get; private set; } 
        public Vector2 LastInputDirection { get; private set; }

        public void Update()
        {
            InputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            SetLastInputDirection();
        }

        private void SetLastInputDirection()
        {
            if (InputDirection != Vector2.zero)
            {
                LastInputDirection = new Vector2(
                    (InputDirection.x != LastInputDirection.x) ? InputDirection.x : LastInputDirection.x,
                    (InputDirection.y != LastInputDirection.y) ? InputDirection.y : LastInputDirection.y
                );
            }
        }
    }
}