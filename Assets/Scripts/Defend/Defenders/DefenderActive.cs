namespace Defend
{
    using UnityEngine;

    public class DefenderActive : Defender
    {
        [SerializeField] private ParticleSystem _fireParticle;
    
        [SerializeField] private int _damage = 15;
        public int damage=>_damage;


        protected override void Attack()
        {

            if (_enemy != null)
            {
                _fireParticle.Play();
                _enemy.GetDamage(_damage);
                _canFire = false;
                StartCoroutine(AttackDelay());
                //Debug.Log($"i {gameObject.name} fire {_enemy.name}");
            }

        }
    }
}