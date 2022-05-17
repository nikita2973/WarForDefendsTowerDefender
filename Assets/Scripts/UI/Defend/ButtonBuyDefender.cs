namespace GameUI
{
    namespace Shop
    {
        using UnityEngine;
        using UnityEngine.UI;
        using TMPro;
        using UnityEngine.EventSystems;
        

        public class ButtonBuyDefender : MonoBehaviour, IPointerClickHandler
        {
            [SerializeField] private UDictionary<string,WordTranslate> _word;
            [Space(100)]
            [SerializeField] private Image _tankImage;
            [SerializeField] private TextMeshProUGUI _tankNameText;
            [SerializeField] private TextMeshProUGUI _tankParamText;

            private DefenderShopInfo _defenderShopInfo;

            private ShopMenuController _menuController;
            public void OnCreate (DefenderShopInfo gDefenderShopInfo, ShopMenuController gMenuController)
            {
               _defenderShopInfo = gDefenderShopInfo;
                _menuController = gMenuController;
                Language language = Language.Ukrainian;
                _tankNameText.text = gDefenderShopInfo.names[language];
                _tankImage.sprite = gDefenderShopInfo.icon;

                string tankParam = "";
                if (gDefenderShopInfo.defender is Defend.DefenderActive)
                {
                 tankParam = $"{_word["Fire speed"].translate[language]} : {gDefenderShopInfo.defender.status.attackDelay} b/s \n" +
         $"{_word["Damage"].translate[language]}: {((Defend.DefenderActive)gDefenderShopInfo.defender).damage}\n" + $"{_word["Distance"].translate[language]}: {gDefenderShopInfo.defender.status.attackDistance}\n" + $"{_word["Price"].translate[language]}: {gDefenderShopInfo.price.priceForBuy}";
                }
                _tankParamText.text = tankParam;

            }

            public void OnPointerClick(PointerEventData eventData)
            {
                _menuController.BuyDefender(_defenderShopInfo);
            }
        }


    }
}