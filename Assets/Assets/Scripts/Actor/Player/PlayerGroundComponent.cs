namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Playerの地面との接地面を表すオブジェクト。
    /// </summary>
    public class PlayerGroundComponent : MonoBehaviour
    {
        public Player Player
        {
            get;
            set;
        }

        private void Start()
        {
            Player = transform.root.gameObject.GetComponent<Player>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            // TODO メソッド化
            Player.OnGround = true;
        }
    }
}
