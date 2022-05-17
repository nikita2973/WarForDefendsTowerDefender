namespace GameUI
{
    namespace Shop
    {
        using UnityEngine;
        [RequireComponent(typeof(ShopMenuController))]
        public class DefenderShopMenuGenerator : MonoBehaviour
        {
            [SerializeField] private DefenderShopInfo[] _defenderItem;

            [SerializeField] private ButtonBuyDefender[] _defenderButtons;
            [SerializeField] private ButtonBuyDefender _defenderButtonSample;
            [SerializeField] private Transform _conteiner;

            private ShopMenuController _menuController;
            private void OnEnable()
            {
                if( _menuController == null)
                {
                    _menuController=GetComponent<ShopMenuController>();
                }
                if( _defenderButtons.Length==0)
                {
           
                    _defenderButtons = new ButtonBuyDefender[_defenderItem.Length]; 
                   for(int i = 0; i < _defenderItem.Length; i++)
                    {
                        _defenderButtons[i] = Instantiate(_defenderButtonSample, _conteiner);
                        _defenderButtons[i].OnCreate(_defenderItem[i],_menuController);
                    }
                }
            }
        }
    }
}