namespace PfProto.State
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Input;

    /// <summary>
    /// Playerが何もしていない状態を表すクラス。
    /// </summary>
    public class PlayerWaitingState : PlayerState
    {
        public PlayerWaitingState (Actor actor)
            : base(actor)
        {
            
        }

        public override void Enter()
        {
            Actor.Animator.SetInteger(
                "player_state", (int)PlayerAnimationNumber.Waiting);
        }

        public override ActorState HandleInput(InputObject input)
        {
            return base.HandleInput(input);
        }
    }
}