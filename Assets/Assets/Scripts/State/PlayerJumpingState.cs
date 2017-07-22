namespace PfProto.State
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Input;

    /// <summary>
    /// Playerのジャンプ時の状態を表すクラス。
    /// </summary>
    public class PlayerJumpingState : PlayerState
    {
        public PlayerJumpingState(Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {
            Actor.Animator.SetInteger(
                "player_state", (int)PlayerAnimationNumber.Jumping);
        }

        public override ActorState HandleInput(InputObject input)
        {
            if (Actor.OnGround)
            {
                return new PlayerWaitingState(Actor);
            }
            return null;
        }
    }
}
