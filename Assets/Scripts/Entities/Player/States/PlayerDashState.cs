using Entities.Player.Factories;

namespace Entities.Player.States
{
    public sealed class PlayerDashState : PlayerBaseState
    {
        public PlayerDashState(PlayerContext context, PlayerStateFactory factory) : base(context, factory)
        {
        }

        protected override void OnStart()
        {
            // Set dash animation
            // Activate all dashing effects
        }

        protected override void OnUpdate()
        {
            // Lock it for the dash duration
            // Move the player into desired direction with set velocity
            // When timer ends state switch is possible
            // Add trail behind player
        }

        protected override void OnExit()
        {
            // Disable all effects
        }

        protected override void UpdateState()
        {
            // Can state switch?
                // Switch state
        }
    }
}