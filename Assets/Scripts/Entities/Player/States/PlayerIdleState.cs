using Entities.Player.Factories;
using UnityEngine;

namespace Entities.Player.States
{
    public sealed class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerContext context, PlayerStateFactory factory) : base(context, factory)
        {
        }

        protected override void OnStart()
        {
            // Set idle animation
        }

        protected override void UpdateState()
        {
            if (Context.PlayerInput.InputDirection != Vector2.zero)
            {
                SwitchState(Factory.Move());
            }
        }
    }
}