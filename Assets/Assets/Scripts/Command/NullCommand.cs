namespace PfProto.Command
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;

    /// <summary>
    /// Actorクラスに対し、何もしないコマンド。
    /// </summary>
    public class NullCommand : Command
    {
        public NullCommand(Actor actor)
            : base(actor)
        {
            
        }

        public override void Execute()
        {
            return;
        }
    }
}
