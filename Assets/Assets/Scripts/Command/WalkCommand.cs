namespace PfProto.Command
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;

    /// <summary>
    /// ActorクラスをWalkさせるコマンド。
    /// </summary>
    public class WalkCommand : Command
    {
        public WalkCommand(Actor actor, float x)
            : base(actor)
        {

        }

        public override void Execute()
        {

        }
    }
}
