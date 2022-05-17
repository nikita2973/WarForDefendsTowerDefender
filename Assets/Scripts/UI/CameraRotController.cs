namespace GameUI
{
    using UnityEngine;

    public class CameraRotController : MonoBehaviour
    {
        [SerializeField] private Camera _cameraLandscape;
        [SerializeField] private Camera _cameraPortrait;
        private bool _isLandscape;

        private void Update()
        {
            if (Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft)
            {
                _isLandscape = true;
            }
            else
            {
                _isLandscape = false;
            }
            _cameraPortrait.gameObject.SetActive(!_isLandscape);
            _cameraLandscape.gameObject.SetActive(_isLandscape);

        }
    }
}