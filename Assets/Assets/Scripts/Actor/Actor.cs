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
        /// <summary>
        /// 横方向移動時にかかる力。
        /// </summary>
        public virtual float VerticalForce
        {
            get { return 500f; }
        }

        /// <summary>
        /// 縦方向移動時にかかる力
        /// </summary>
        public virtual float HorizontalForce
        {
            get { return 50f; }
        }

        public virtual float MaxVelocityX
        {
            get { return 100f; }
        }

        public virtual float MaxVelocityY
        {
            get { return 100f; }
        }

        public bool ExceedVelocityX()
        {
            float current = Mathf.Abs(Rigitbody2D.velocity.x);
            return (current > MaxVelocityX);
        }

        public bool ExceedVelocityY()
        {
            float current = Mathf.Abs(Rigitbody2D.velocity.y);
            return (current > MaxVelocityY);
        }

        /// <summary>
        /// 現在の向き。0以上なら右向き。0未満なら左向き。
        /// </summary>
        public float CurrentDirection
        {
            get;
            set;
        }

        public bool FaceRight()
        {
            return CurrentDirection >= 1f;
        }

        public bool FaceLeft()
        {
            return CurrentDirection <= -1f;
        }

        /// <summary>
        /// 地面に接地しているかのフラグ。
        /// </summary>
        public bool OnGround
        {
            get;
            set;
        }

        /// <summary>
        /// 現在のステート。具体的な状態遷移は、継承クラス側で管理。
        /// </summary>
        public ActorState CurrentState
        {
            get;
            set;
        }

        public Animator Animator
        {
            get;
            set;
        }

        public Rigidbody2D Rigitbody2D
        {
            get;
            set;
        }

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// このインスタンスの初期化処理。
        /// </summary>
        protected virtual void Initialize()
        {
            CurrentDirection = 1f;
            CurrentState = new ActorState(this);
            OnGround = true;

            // よくアクセスするコンポーネントは、プロパティに持っておく。
            Animator = gameObject.GetComponent<Animator>();
            Rigitbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// スプライトを反転させる。
        /// </summary>
        /// <param name="sign">そのままにしたい場合は0以上。反転させたい場合は負数。</param>
        public void FlipSprite(float sign)
        {
            if (sign == 0.0f)
            {
                return;
            }

            Vector2 v = gameObject.transform.localScale;
            v.x = (sign >= 0f) ? 1f : -1f;
            gameObject.transform.localScale = v;
        }

        /// <summary>
        /// このオブジェクトが現在停止しているかどうかを判定する。
        /// </summary>
        public bool IsStopped()
        {
            // TODO Stop判定処理は決め打ちなので、後で検討すること。
            float x = Rigitbody2D.velocity.x;
            return (x > -5f && x < 5f);
        }

        /// <summary>
        /// InputObjectクラスを受け取り、入力に応じた処理を行う。
        /// </summary>
        public virtual void HandleInput(InputObject input)
        {
            ActorState state = CurrentState.HandleInput(input);
            if (state != null)
            {
                CurrentState = state;
                CurrentState.Enter();
            }
        }
    }
}
