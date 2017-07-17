namespace PfProto.Command
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;

    /// <summary>
    /// ActorクラスをJumpさせるコマンド。
    /// </summary>
    public class JumpCommand : Command
    {
        public JumpCommand(Actor actor, float y)
            : base(actor)
        {

        }

        public override void Execute()
        {
            
        }
    }
}
