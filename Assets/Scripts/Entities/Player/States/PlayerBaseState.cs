using Entities.Player.Enums;
using Entities.Player.Factories;
using Extendables.Generics;

namespace Entities.Player.States
{
    public abstract class PlayerBaseState
    {
        protected readonly PlayerContext Context;
        protected readonly PlayerStateFactory Factory;

        protected PlayerBaseState(PlayerContext context, PlayerStateFactory factory)
        {
            Context = context;
            Factory = factory;
        }

        protected virtual void OnStart()
        { }

        protected virtual void OnUpdate()
        { }
        
        protected virtual void OnFixedUpdate() 
        { }
        
        protected virtual void OnExit() 
        { }

        protected abstract void UpdateState();

        protected void SwitchState(PlayerBaseState state)
        {
            OnExit();

            Context.State = state;

            state.OnStart();
        }

        public void Update()
        {
            UpdateState();
            OnUpdate();
        }

        public void FixedUpdate()
        {
            OnFixedUpdate();
        }
    }
}