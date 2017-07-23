namespace PfProto.Actor
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour
    {

        /// <summary>
        /// 生成するEnemyのプレハブ。
        /// </summary>
        [SerializeField]
        private GameObject enemyPrefab;
        public GameObject EnemyPrefab
        {
            get { return enemyPrefab; }
            set { enemyPrefab = value; }
        }

        /// <summary>
        /// Enemyを生成済みかどうか判断するフラグ。
        /// </summary>
        public bool HasSpawned
        {
            get;
            set;
        }

        private void Start()
        {
            HasSpawned = false;
        }

        private void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && ! HasSpawned)
            {
                Spawn();
                HasSpawned = true;
            }
        }

        /// <summary>
        /// 新規にEnemyインスタンスを生成する。
        /// </summary>
        private GameObject Spawn()
        {
            GameObject enemy = Instantiate(
                EnemyPrefab, transform.position, transform.rotation);
            // TODO インスペクタなどで、好きな型のEnemyをAddComponentできるようにしたい。
            enemy.AddComponent<Enemy>();
            return enemy;
        }
    }
}
