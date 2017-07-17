namespace PfProto.Handler
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Actor;
    using Command;

    /// <summary>
    /// Actorクラスの状態を表すクラス(Stateパターン)。
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        public Player Player
        {
            get;
            set;
        }

        private void Start()
        {

        }

        private void Update()
        {
            DetectInput();
        }

        /// <summary>
        /// このインスタンスを初期化する。
        /// </summary>
        /// <remarks>
        /// インスタンス生成後に、必ずこのメソッドをコールすること。
        /// </remarks>
        public void Initialize(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// ユーザからの入力を元にCommandインスタンスを生成し、Playerに通知する。
        /// </summary>
        public void DetectInput()
        {
            
        }
    }
}
