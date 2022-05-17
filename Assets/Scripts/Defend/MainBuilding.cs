namespace Defend
{

    using UnityEngine;

    public class MainBuilding : MonoBehaviour
    {
        [SerializeField] private int _hp = 100;
        [SerializeField] private ParticleSystem _boomParticle;
        [SerializeField] private float _particalDelayTime = 0.1f;
        private void Start()
        {
            if (_boomParticle == null)
            {
                _boomParticle = GetComponentInChildren<ParticleSystem>();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy.EnemyMove enemy))
            {
                GetDamage(enemy.EnemyStatus.damage);
                _boomParticle.startDelay = _particalDelayTime;
                _boomParticle.Play();
                Destroy(enemy.gameObject, 1f);

            }
        }
        private void GetDamage(int damage)
        {
            _hp = _hp - damage;
        }
    }
}