namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Input;
    using Actor;

    public class EnemyState : ActorState
    {
        public EnemyState(Actor actor)
            : base(actor)
        {

        }

        public override void Enter()
        {
            Assert.IsTrue(false, "You must call derivative method.");
        }

        public override ActorState HandleInput(InputObject input)
        {
            if (input is HorizontalInputObject)
            {
                Vector2 v = Vector2.zero;
                if (input.GetType() == typeof(RightInputObject))
                {
                    if (Actor.ExceedVelocityX() && Actor.FaceRight())
                    {
                        return null;
                    }
                    v = Vector2.right;
                }
                else if (input.GetType() == typeof(LeftInputObject))
                {
                    if (Actor.ExceedVelocityX() && Actor.FaceLeft())
                    {
                        return null;
                    }
                    v = Vector2.left;
                }
                else
                {
                    Assert.IsTrue(false, "Horizontal Input is invalid.");
                }

                Actor.Rigitbody2D.AddForce(
                    v* Actor.HorizontalForce, ForceMode2D.Impulse);
                Actor.FlipSprite(v.x);

                return new EnemyWalkingState(Actor);
            }

            if (Actor.IsStopped())
            {
                return new EnemyWaitingState(Actor);
            }

            return null;
        }
    }
}
