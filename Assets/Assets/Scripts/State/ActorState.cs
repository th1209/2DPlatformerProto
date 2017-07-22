namespace PfProto.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Input;

    /// <summary>
    /// Actorクラスの状態を表すクラス(Stateパターン)。
    /// </summary>
    public class ActorState
    {
        public Actor Actor
        {
            get;
            set;
        }

        public ActorState(Actor actor)
        {
            Actor = actor;
        }

        /// <summary>
        /// 他のステートから、このステートに切り替わった際に呼ばれるメソッド。
        /// 状態の切り替わり時に必要な初期化処理を実施する。
        /// </summary>
        public virtual void Enter()
        {
            
        }

        /// <summary>
        /// 渡されたInputObjectに対し、適切な処理を実行する。
        /// </summary>
        /// <returns>状態遷移する場合は他のステート。引き続きこの状態の場合はnull。</returns>
        public virtual ActorState HandleInput(InputObject input)
        {
            return null;
        }
    }
}
