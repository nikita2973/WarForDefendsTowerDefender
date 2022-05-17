namespace GameUI
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class AddDefendButton : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private Shop.ShopMenuController _shopMenuController;
        [SerializeField] private Defend.DefenderFieldController _defender;
        [SerializeField] private Sprite _openSelectMode;
        [SerializeField] private Sprite _closeSelectMode;
        
        private bool _selectModeIsOpen=false;

        private Image _selectedImage;

        private void Start()
        {
            _selectedImage = GetComponent<Button>().image;
           
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UpdateImage();
            _shopMenuController.gameObject.SetActive(false);
            _defender.ShowMeFieldsForSelect(_selectModeIsOpen);
        }

        private void UpdateImage()
        {
            if (_selectModeIsOpen)
            {
                _selectModeIsOpen = false;
                _selectedImage.sprite = _openSelectMode;
            }
            else
            {
                _selectModeIsOpen = true;
                _selectedImage.sprite = _closeSelectMode;
            }
        }

    }
}