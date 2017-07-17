namespace PfProto.Command
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;

    /// <summary>
    /// Actorクラスに対する、何らかの処理を表すクラス(Commandパターン)。
    /// </summary>
    public class Command
    {
        protected Actor Actor
        {
            get;
            set;
        }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <remarks>
        /// 各派生クラスで実現したい処理が異なるため、
        /// 派生側クラスのコンストラクタで、追加の引数を取ることがあることに注意。
        /// そのため、呼び出し側のクラスでは、このコンストラクタをポリモーフィックに扱うことはできない。
        /// </remarks>
        public Command(Actor actor)
        {
            
        }

        /// <summary>
        /// コンストラクタで受け取ったインスタンスに対して、何らかの処理を実行する。
        /// </summary>
        public virtual void Execute()
        {
            
        }
    }
}
