namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Command;
    //using State;

    public enum PlayerState
    {
        WAITING = 0,
        WALKING = 1,
        JUMPING = 2,
    }

    /// <summary>
    /// 自プレイヤーを表すクラス。
    /// </summary>
    public class Player : Actor
    {
        public float VerticalForce
        {
            get { return 500f; }
        }

        public float HorizontalForce
        {
            get { return 50f; }
        }

        // 現在の向き。0以上なら右向き。0未満なら左向き。
        public float CurrentDirection
        {
            get;
            set;
        }

        public bool OnGround
        {
            get;
            set;
        }

        public PlayerState CurrentState
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

        public void Start()
        {
            CurrentDirection = 1f;
            CurrentState = PlayerState.WAITING;
            OnGround = true;

            Animator = gameObject.GetComponent<Animator>();
            Rigitbody2D = gameObject.GetComponent<Rigidbody2D>();

        }

        public void Update()
        {
            CheckInputAndChangeState();
            FlipSprite(Input.GetAxisRaw("Horizontal"));
        }

        private PlayerState CheckInputAndChangeState()
        {
            switch (CurrentState)
            {
                case PlayerState.WAITING:
                case PlayerState.WALKING:
                    if (Input.GetButton("Jump"))
                    {
                        Rigitbody2D.AddForce(Vector2.up * VerticalForce , ForceMode2D.Impulse);
                        Animator.SetInteger("player_state", (int)PlayerState.JUMPING);
                        CurrentState = PlayerState.JUMPING;
                        OnGround = false;
                        break;
                    }
                    if (Input.GetButton("Horizontal"))
                    {
                        //TODO 一定以上の速度にならない工夫が必要。
                        Vector2 v = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
                        Rigitbody2D.AddForce(v * HorizontalForce, ForceMode2D.Impulse);
                        Animator.SetInteger("player_state", (int)PlayerState.WALKING);
                        CurrentState = PlayerState.WALKING;
                        break;
                    }

                    if (IsStopped())
                    {
                        Animator.SetInteger("player_state", (int)PlayerState.WAITING);
                        CurrentState = PlayerState.WAITING;
                    }
                    break;
                case PlayerState.JUMPING:
                    if (OnGround)
                    {
                        Animator.SetInteger("player_state", (int)PlayerState.WAITING);
                        CurrentState = PlayerState.WAITING;
                        break;
                    }
                    break;
                default:
                    Assert.IsTrue(false, "Player state is invalid.");
                    break;
            }

            return CurrentState;
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

            Vector2 scale = gameObject.transform.localScale;
            scale.x = (sign >= 0f) ? 1f : -1f;
            gameObject.transform.localScale = scale;
        }

        public bool IsStopped()
        {
            float x = Rigitbody2D.velocity.x;
            return (x > -5f && x < 5f);
        }

        public override void HandleCommand(Command command)
        {
            
        }
    }
}
