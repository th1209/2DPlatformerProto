namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Command;

    /// <summary>
    /// Actorクラスの状態を表すクラス(Stateパターン)。
    /// </summary>
    public class ActorState
    {
        /// <summary>
        /// 他のステートから、このステートに切り替わった際に呼ばれるメソッド。
        /// 状態の切り替わり時に必要な初期化処理を実施する。
        /// </summary>
        public void Enter(Actor actor)
        {
            
        }

        /// <summary>
        /// Actorクラスに対し、適切なCommandを実施する。
        /// </summary>
        /// <returns>このステートもしくは他のステート。</returns>
        public virtual ActorState HandleCommand(Actor actor, Command command)
        {
            return new ActorState();
        }
    }
}
