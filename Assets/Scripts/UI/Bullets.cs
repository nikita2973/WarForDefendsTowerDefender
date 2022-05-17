namespace GameUI
{
    using System.Collections;
    using UnityEngine;
    using TMPro;
    public class Bullets : MonoBehaviour
    {
        [HideInInspector]
        public static Bullets instance;

        [SerializeField] private TextMeshProUGUI _bulletCountText;
        [SerializeField] private int _bulletCount;
        public int bulletCount => _bulletCount;
        private int _needCount;

 
        private void Start()
        {
            instance = this;
            BulletCountUpdate(_bulletCount);
        }

        public void GetBullets(int gBulletCount)
        {
        
            StartCoroutine(TextAnimation(gBulletCount));
        }

        private IEnumerator TextAnimation(int gBulletCount)
        {
            if (_needCount != 0)
            {
                _needCount = gBulletCount + _needCount;
            }
            else
            {
                _needCount = gBulletCount + _bulletCount;
            }
            bool plus = _needCount > _bulletCount;
          
            if (plus)
            {
                do
                {
                    yield return new WaitForSecondsRealtime(0.05f);

                    BulletCountUpdate(_bulletCount + 1);
                }
                while (_bulletCount < _needCount);
            }
            else
            {
                do
                {
                    yield return new WaitForSecondsRealtime(0.05f);

                    BulletCountUpdate(_bulletCount - 1);
                }
                while (_bulletCount > _needCount + 1) ;
            }
        }

        private void BulletCountUpdate(int gBulletCount)
        {
            _bulletCount = gBulletCount;
        
            _bulletCountText.text = gBulletCount.ToString();
        }
    }
}