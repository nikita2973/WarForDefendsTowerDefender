namespace Defend
{
    using UnityEngine;
    using Enemy;
    using System.Collections;

    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Defender : MonoBehaviour
    {
        [SerializeField] protected DefenderStatus _status;
        public DefenderStatus status => _status;

        [SerializeField] protected SphereCollider _trigger;
        [SerializeField] protected Transform _turrele;

        protected bool _attack = false;

        protected bool _canFire = true;

        private WaitForSeconds _attackTime;
 
        protected EnemyStatus _enemy;

        protected void Start()
        {
            _attackTime = new WaitForSeconds(_status.attackDelay);

            if (_trigger == null)
            {
                _trigger = GetComponent<SphereCollider>();

            }
            _trigger.isTrigger = true;
            _trigger.radius = _status.attackDistance;

        }

        protected void FixedUpdate()
        {
            if (_enemy != null)
            {
                // Determine which direction to rotate towards
                Vector3 targetDirection = _enemy.transform.position - _turrele.position;

                // The step size is equal to speed times frame time.
                float singleStep = _status.speedTurreleRotation * Time.fixedDeltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(_turrele.forward, targetDirection, singleStep, 0.0f);

                Debug.DrawRay(_turrele.position, newDirection, Color.red);

                _turrele.rotation = Quaternion.LookRotation(newDirection);

              if(CheckRotation(targetDirection) &&_canFire)
                {
                    Attack();
                }


            }
        
        
        }

        private bool CheckRotation( Vector3 gDir)
        {
            float scalar=Vector3.Angle(gDir, _turrele.forward);

            if (scalar > -5.0f && scalar < 5.0f)
                return true;
            
                return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EnemyMove enemy))
            {
      
                if (!_attack )
                {
                    _attack = !_attack;
                    if (_enemy == null)
                    {
                        _enemy = enemy.EnemyStatus;
                    }
                }

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EnemyMove enemy))
            {
                if (_enemy == enemy)
                {
                    _attack = false; _enemy = null;
            
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            
            if (other.gameObject.TryGetComponent(out EnemyMove enemy) && _enemy == null)
            {
                _attack = true;
                _enemy = enemy.EnemyStatus;

          
           
            }
        }

        protected IEnumerator AttackDelay()
        {
            while (!_canFire)
            {
            yield return _attackTime;
               _canFire = true;
            }
        }

        protected virtual void Attack() { }
    }

    [System.Serializable]
    public class DefenderStatus
    {
        [SerializeField] private float _attackDelay;
        public float attackDelay => _attackDelay;

        [SerializeField] private int _attackDistance;
        public int attackDistance => _attackDistance;

        [SerializeField] private float _speedTurreleRotationDelay = 0.01f;
        public float speedTurreleRotationDelay => _speedTurreleRotationDelay;

        [SerializeField] private float _speedTurreleRotation = 0.1f;
        public float speedTurreleRotation => _speedTurreleRotation;

        private GameUI.Shop.DefenderShopInfo _defenderShopInfo;
        public GameUI.Shop.DefenderShopInfo defenderShopInfo=>_defenderShopInfo;

        public void AddShopInfo(GameUI.Shop.DefenderShopInfo gDefenderShopInfo)
        {
            if (_defenderShopInfo == null)
            {
                _defenderShopInfo = gDefenderShopInfo;
            }
        }

    }
}