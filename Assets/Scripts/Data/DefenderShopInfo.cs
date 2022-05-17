namespace GameUI
{
    namespace Shop
    {
        using UnityEngine;
        using Defend;

        [CreateAssetMenu(menuName = "Defend/Defend Item")]
        public class DefenderShopInfo : ScriptableObject
        {
            [SerializeField] private Price _price;
            public Price price => _price;

            [SerializeField] private Defender _defender;
            public Defender defender => _defender;

            [SerializeField] private Sprite _icon;
            public Sprite icon => _icon;
            [SerializeField] private UDictionary<Language, string> _names;
            public UDictionary<Language, string> names => _names;
        }
        [System.Serializable]
        public class Price
        {
            [SerializeField] private int _priceForBuy;
            public int priceForBuy => _priceForBuy;

            [SerializeField] private int _priceForSell;
            public int priceForSell => _priceForSell;

        }
    }
    public enum Language
    {
        English,
        Ukrainian

    }
}
