namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Input;
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

        public override void HandleInput(InputObject input)
        {
            switch (CurrentState)
            {
                case PlayerState.WAITING:
                case PlayerState.WALKING:
                    if (input.GetType() == typeof(JumpInputObject))
                    {
                        Debug.Log("Jump");
                        Rigitbody2D.AddForce(Vector2.up * VerticalForce, ForceMode2D.Impulse);

                        Animator.SetInteger("player_state", (int)PlayerState.JUMPING);
                        CurrentState = PlayerState.JUMPING;

                        OnGround = false;

                        break;
                    }
                    //TODO 一定以上の速度にならない工夫が必要。
                    if (input is HorizontalInputObject)
                    {
                        Vector2 v = Vector2.zero;
                        if (input.GetType() == typeof(RightInputObject))
                        {
                            v = Vector2.right;
                        } 
                        else if(input.GetType() == typeof(LeftInputObject))
                        {
                            v = Vector2.left;
                        } 
                        else
                        {
                            Assert.IsTrue(false, "Horizontal Input is invalid.");
                        }

                        Rigitbody2D.AddForce(v * HorizontalForce, ForceMode2D.Impulse);

                        FlipSprite(v.x);

                        Animator.SetInteger("player_state", (int)PlayerState.WALKING);
                        CurrentState = PlayerState.WALKING;

                        break;
                    }

                    if (IsStopped())
                    {
                        Animator.SetInteger("player_state", (int)PlayerState.WAITING);
                        CurrentState = PlayerState.WAITING;

                        break;
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
            // TODO Stop判定処理は決め打ちなので、後で検討すること。
            float x = Rigitbody2D.velocity.x;
            return (x > -5f && x < 5f);
        }
    }
}
