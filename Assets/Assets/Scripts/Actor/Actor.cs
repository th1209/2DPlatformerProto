namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Command;
    using State;

    /// <summary>
    /// 自プレイヤーや敵プレイヤーを表すクラス。
    /// </summary>
    public class Actor : MonoBehaviour
    {
        //public ActorState State
        //{
        //    get;
        //    set;
        //}

        private void Start()
        {
            
        }

        private void Update()
        {

        }

        /// <summary>
        /// Commandクラスを受け取り、状態に応じた処理を実行する。
        /// </summary>
        public virtual void HandleCommand(Command command)
        {

        }
    }
}
