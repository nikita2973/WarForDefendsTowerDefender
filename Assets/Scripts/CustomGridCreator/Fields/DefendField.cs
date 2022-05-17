namespace CustomGrid
{
    using UnityEngine;
    using Defend;
    public class DefendField : Field, ICllickingObject
    {
        [SerializeField]private DefendPointer _defendPointer;
        public DefendPointer defendPointer => _defendPointer;

        private Defender _defender;
        public Defender defender=>_defender;
        public void AddDefender(GameUI.Shop.DefenderShopInfo gDefenderShopInfo)
        {
            if (isFree)
            {
                _defender = Instantiate(gDefenderShopInfo.defender, new Vector3(transform.position.x, 0.54f, transform.position.z), Quaternion.identity, transform.parent.parent);
                isFree = false;
                _defender.gameObject.name = gDefenderShopInfo.names[GameUI.Language.Ukrainian];
                _defender.status.AddShopInfo(gDefenderShopInfo);
                defendPointer.ShowPointer(false);
            }
        }  
        public void OnObjectClick()
        {
            if (defendPointer.gameObject.activeSelf) {
                
                if (transform.parent.TryGetComponent(out GameUI.Shop.DefenderShopMenuOpener defenderShopMenuOpener))
                {
                    defenderShopMenuOpener.OpenMenuFor(this);
                }
                
            }
        }
    }
}