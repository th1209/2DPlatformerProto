namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Input;
    using State;

    public enum EnemyAnimationNumber
    {
        Waiting = 0,
        Walking = 1,
        Jumpining = 2,
    }

    public class Enemy : Actor
    {
        public EnemyAi Ai
        {
            get;
            set;
        }

        protected override void Initialize()
        {
            base.Initialize();
            CurrentDirection = -1f;
            CurrentState = new EnemyWaitingState(this);

            Ai = new EnemyGoStraightOnAi();
        }

        private void Update()
        {
            InputObject input = Ai.DecideAction();
            Debug.Log(input);
            HandleInput(input);
        }
    }
}
