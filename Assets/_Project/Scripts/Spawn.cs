using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpicGameJam
{
    public class Spawn : MonoBehaviour
    {
        public List<GameObject> enemies = new List<GameObject>();
        [SerializeField] float spawnRate;

        private float _x, _y;
        private Vector3 _spawnPos;

        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            _x = Random.Range(-3, 3);
            _y = Random.Range(-2, 3);
            _spawnPos.x += _x;
            _spawnPos.y += _y;
            Instantiate(enemies[0], _spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            StartCoroutine(SpawnEnemy());
        }
    
    }
}
