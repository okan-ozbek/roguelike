using System.Collections.Generic;
using Entities.Player.Enums;
using Entities.Player.States;
using Extendables.Generics;

namespace Entities.Player.Factories
{
    public sealed class PlayerStateFactory
    {
        private readonly Dictionary<PlayerStateEnum, PlayerBaseState> _states;

        public PlayerStateFactory(PlayerContext context)
        {
            _states = new Dictionary<PlayerStateEnum, PlayerBaseState>
            {
                { PlayerStateEnum.Idle, new PlayerIdleState(context, this) },
                { PlayerStateEnum.Move, new PlayerMoveState(context, this) },
                { PlayerStateEnum.Dash, new PlayerDashState(context, this) }
            };
        }

        public PlayerBaseState Idle()
        {
            return _states[PlayerStateEnum.Idle];
        }
        
        public PlayerBaseState Move()
        {
            return _states[PlayerStateEnum.Move];
        }
        
        public PlayerBaseState Dash()
        {
            return _states[PlayerStateEnum.Dash];
        }
    }
}