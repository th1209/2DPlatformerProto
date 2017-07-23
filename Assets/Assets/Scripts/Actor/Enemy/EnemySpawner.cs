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
            Debug.Log(HasSpawned);
        }

        //private void OnCollisionEnter2D(Collision2D other)
        //{
        //    Debug.Log("Enter");
        //    if (other.gameObject.tag == "Player") {
        //        Debug.Log("Player Enter");
        //        Spawn();
        //        HasSpawned = true;
        //    }
        //}
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag == "Player" && ! HasSpawned)
            {
                Debug.Log("Player Enter");
                Spawn();
                HasSpawned = true;
            }
        }

        private GameObject Spawn()
        {
            GameObject enemy = Instantiate(
                EnemyPrefab, transform.position, transform.rotation);
            //enemy.AddComponent<Rigidbody2D>();
            //enemy.AddComponent<BoxCollider2D>();
            return enemy;
        }
    }
}
