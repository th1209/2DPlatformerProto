namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Assertions;

    using Input;
    using State;

    public class EnemyAi
    {
        /// <summary>
        /// このEnemyが取るべき行動を決定し返す。
        /// </summary>
        public virtual InputObject DecideAction()
        {
            Assert.IsTrue(false, "You must call derivative method.");
            return null;
        }
    }
}
