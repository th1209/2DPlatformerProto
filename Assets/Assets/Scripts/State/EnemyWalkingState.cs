namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Input;
    using Actor;

    public class EnemyWalkingState : EnemyState
    {
        public EnemyWalkingState(Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {
            Actor.Animator.SetInteger(
                "enemy_state", (int)EnemyAnimationNumber.Walking);
        }

        public override ActorState HandleInput(InputObject input)
        {
            return base.HandleInput(input);
        }
    }
}
