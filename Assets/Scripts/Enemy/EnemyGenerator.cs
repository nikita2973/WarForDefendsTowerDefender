namespace Enemy
{
    using CustomGrid;
    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;

    public class EnemyGenerator : MonoBehaviour
    {

        [SerializeField] private EnemySpawnParameter[] _enemySpawnQueue;

        [SerializeField] private GridController _gridController;

        [SerializeField] private bool _startWithFirstEnemyPoint = true;

        [SerializeField] private bool _generationEnemy = true;

        private Queue<Field> _fieldQueueEnemyMoving;

        private Vector3 _spawnPos;


        private void Start()
        {
            if (_gridController == null) _gridController = FindObjectOfType<GridController>();

            _fieldQueueEnemyMoving = _gridController.GenerateQueueForEnemy(_startWithFirstEnemyPoint);

            if (_fieldQueueEnemyMoving != null && _enemySpawnQueue != null)
            {
                _spawnPos = new Vector3(_fieldQueueEnemyMoving.Peek().transform.position.x, 0.9f, _fieldQueueEnemyMoving.Peek().transform.position.z);

               StartCoroutine( GenerateEnemy());
            }
        }

        private IEnumerator GenerateEnemy()
        {

                int lastEnemyIndexSpawn = 0;
            while (_generationEnemy)
            {
                if (lastEnemyIndexSpawn < _enemySpawnQueue.Length)
                {
                    yield return new WaitForSeconds(_enemySpawnQueue[lastEnemyIndexSpawn].delayTime);

                    EnemyMove enemy = Instantiate(_enemySpawnQueue[lastEnemyIndexSpawn].enemy, _spawnPos, Quaternion.identity, transform);

                    enemy.GetQueueEnemyMovePoint(_fieldQueueEnemyMoving);
                lastEnemyIndexSpawn++;
                }
                else
                {
                    _generationEnemy = false;
                    StopCoroutine( GenerateEnemy());
                }
            }
            

        }
    }


    [System.Serializable]
    public struct EnemySpawnParameter
    {
        [SerializeField] private float _delayTime;
        public float delayTime => _delayTime;

        [SerializeField] private EnemyMove _enemy;
        public EnemyMove enemy => _enemy;
    }

}
