namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Input;

    /// <summary>
    /// Playerが歩いている状態を表すクラス。
    /// </summary>
    public class PlayerWalkingState : PlayerState
    {
        public PlayerWalkingState (Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {
            Actor.Animator.SetInteger(
                "player_state", (int)PlayerAnimationNumber.Walking);
        }

        public override ActorState HandleInput(InputObject input)
        {
            return base.HandleInput(input);
        }
    }
}