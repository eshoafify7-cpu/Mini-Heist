

namespace Delivery.Player.States {
    public abstract class PlayerBaseState {

        protected PlayerStateMachine playerSM = PlayerStateMachine.Instance;

        public virtual void Enter(PlayerData player) {
        }
        
        public virtual void Update(PlayerData player) {
        }
        
        public virtual void FixedUpdate(PlayerData player) {
        }
        
        public virtual void Exit(PlayerData player) {
        }

    }
}
