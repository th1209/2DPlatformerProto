namespace PfProto.State
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Actor;
    using Input;

    /// <summary>
    /// Playerクラス固有の状態を表すクラス。
    /// </summary>
    /// <remarks>
    /// Playerクラスの状態に関する処理のうち、
    /// 全ての状態に共通する操作は、このクラスにまとめること。
    /// </remarks>
    public class PlayerState : ActorState
    {
        public PlayerState(Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {

        }

        public override ActorState HandleInput(InputObject input)
        {
            if (input is JumpInputObject)
            {
                Actor.Rigitbody2D.AddForce(
                    Vector2.up * Actor.VerticalForce, ForceMode2D.Impulse);
                Actor.OnGround = false;

                return new PlayerJumpingState(Actor);
            }

            //TODO 一定以上の速度にならない工夫が必要。
            if (input is HorizontalInputObject)
            {
                Vector2 v = Vector2.zero;
                if (input.GetType() == typeof(RightInputObject))
                {
                    v = Vector2.right;
                }
                else if (input.GetType() == typeof(LeftInputObject))
                {
                    v = Vector2.left;
                }
                else
                {
                    Assert.IsTrue(false, "Horizontal Input is invalid.");
                }

                Actor.Rigitbody2D.AddForce(
                    v * Actor.HorizontalForce, ForceMode2D.Impulse);
                Actor.FlipSprite(v.x);

                return new PlayerWalkingState(Actor);
            }

            if (Actor.IsStopped())
            {
                return new PlayerWaitingState(Actor);
            }

            return null;
        }
    }
}
