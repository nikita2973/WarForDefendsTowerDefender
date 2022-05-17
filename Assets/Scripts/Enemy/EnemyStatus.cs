namespace Enemy
{
    using UnityEngine;
    public class EnemyStatus : MonoBehaviour
    {
        public float speedEnemy => _speedEnemy;
        [SerializeField] private float _speedEnemy = 0.1f;

        [SerializeField] private int _destroyReward = 10;
        [SerializeField] private int _hp = 100;

        [SerializeField]private HPBar _hpBar;

        [SerializeField] private int _damage = 10;
        public int damage=> _damage;
        private int _maxHP;

        private void Start()
        {
            _maxHP = _hp;
        }

        public void GetDamage(int gettingDamage)
        {
            _hp =_hp- gettingDamage;
            _hpBar.ChangeHpBar(_hp,_maxHP); 
            if (_hp <= 0)
            {
               GameUI.Bullets.instance.GetBullets(_destroyReward);

                Destroy(gameObject);
            }
        }
        
    }
}