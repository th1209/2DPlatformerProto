namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Input;
    using State;

    public enum PlayerAnimationNumber
    {
        Waiting = 0,
        Walking = 1,
        Jumping = 2,
    }

    /// <summary>
    /// 自プレイヤーを表すクラス。
    /// </summary>
    public class Player : Actor
    {
        protected override void Initialize()
        {
            base.Initialize();
            CurrentState = new PlayerWaitingState(this);
        }
    }
}
