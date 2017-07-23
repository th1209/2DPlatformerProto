namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Input;

    public class EnemyGoStraightOnAi : EnemyAi
    {
        
        public override InputObject DecideAction()
        {
            return new LeftInputObject();
        }
    }
}
