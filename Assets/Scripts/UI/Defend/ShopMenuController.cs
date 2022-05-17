namespace GameUI
{
    namespace Shop
    {
        using UnityEngine;
        using UnityEngine.Events;

        public class ShopMenuController : MonoBehaviour
        {
            private CustomGrid.DefendField _defendField;

            [SerializeField] private UnityEvent _onOpen;
            [SerializeField] private UnityEvent _onClose;
            private void OnEnable()
            {
                _onOpen.Invoke();
            }
            private void OnDisable()
            {
                _onClose.Invoke();
            }

            public void OpenMenuFor(CustomGrid.DefendField gDefendField)
            {
                _defendField = gDefendField;
            }

            public void BuyDefender(DefenderShopInfo gDefenderShopInfo)
            {
                if (Bullets.instance.bulletCount >= gDefenderShopInfo.price.priceForBuy)
                {
                    Bullets.instance.GetBullets(- gDefenderShopInfo.price.priceForBuy); 
                  

                   _defendField.AddDefender(gDefenderShopInfo);
                    _defendField = null;
                    gameObject.SetActive(false);
                }
            } 
        }
    }
}