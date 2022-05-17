namespace Enemy
{
    using CustomGrid;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [RequireComponent(typeof(EnemyStatus))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private EnemyStatus _enemyStatus;
        public EnemyStatus EnemyStatus => _enemyStatus;
        private Queue<Field> _fieldQueueEnemy;
        private bool moving = true;

        private void Awake()
        {
            if (_enemyStatus == null) _enemyStatus = GetComponent<EnemyStatus>();
        }

        public void GetQueueEnemyMovePoint(Queue<Field> fieldQueueEnemy)
        {
            if (fieldQueueEnemy == null) return;
            
            _fieldQueueEnemy = new Queue<Field>(fieldQueueEnemy);
            StartCoroutine(Move());
            
        }

        private IEnumerator Move()
        {
          
            _fieldQueueEnemy.Dequeue();
            WaitForSeconds waitForSeconds =new WaitForSeconds(0.1f);
            while (moving)
            {
                Vector3 targetPos = new Vector3(_fieldQueueEnemy.Peek().transform.position.x, transform.position.y, _fieldQueueEnemy.Peek().transform.position.z);
                transform.LookAt(targetPos);
                if (_fieldQueueEnemy.Count <= 1)
                {
                    moving = false;
                    StopCoroutine(Move());
              
                 
                }
                while (transform.position !=targetPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position,targetPos, _enemyStatus.speedEnemy) ;
                    yield return waitForSeconds;
                }
                _fieldQueueEnemy.Dequeue();

            }
        }
     
        
    }
}