namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Input;
    using Actor;

    public class EnemyWaitingState : EnemyState
    {
        public EnemyWaitingState(Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {
            Actor.Animator.SetInteger(
                "enemy_state", (int)EnemyAnimationNumber.Waiting);
        }

        public override ActorState HandleInput(InputObject input)
        {
            return base.HandleInput(input);
        }
    }
}
