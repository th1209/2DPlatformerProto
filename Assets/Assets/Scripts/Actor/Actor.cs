namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Input;
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
        /// InputObjectクラスを受け取り、入力に応じた処理を行う。
        /// </summary>
        public virtual void HandleInput(InputObject input)
        {

        }
    }
}
