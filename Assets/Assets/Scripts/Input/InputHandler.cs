namespace PfProto.Input
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Actor;
    using Command;

    public class InputHandler : MonoBehaviour
    {
        /// <summary>
        /// 通知先のActor。
        /// </summary>
        [SerializeField]
        private GameObject actor;
        public GameObject Actor
        {
            get { return actor; }
            set { actor = value; }
        }

        private void Update()
        {
            InputObject input = DetectInput();
            Actor.GetComponent<Actor>().HandleInput(input);
        }

        /// <summary>
        /// ユーザからの入力を検出し、InputObjectインスタンスを返す(入力の抽象化)。
        /// </summary>
        public InputObject DetectInput()
        {
            if (Input.GetButton("Jump"))
            {
                return new JumpInputObject();
            }
            if (Input.GetButton("Horizontal"))
            {
                float value = Input.GetAxisRaw("Horizontal");

                Assert.AreNotEqual(0f, value, "Input value is impossible.");

                if (value > 0f)
                {
                    return new RightInputObject();
                }
                else
                {
                    return new LeftInputObject();
                }
            }

            return new NullInputObject();
        }
    }
}
