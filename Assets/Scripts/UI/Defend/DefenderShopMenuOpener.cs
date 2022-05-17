namespace GameUI {
    namespace Shop { 
using UnityEngine;

    public class DefenderShopMenuOpener : MonoBehaviour
    {
            [SerializeField] private ShopMenuController _shopMenuController;

        public void OpenMenuFor(CustomGrid.DefendField gDefendField)
        {
                _shopMenuController.OpenMenuFor(gDefendField);
                _shopMenuController.gameObject.SetActive(true);
        }
    }

    } 
}