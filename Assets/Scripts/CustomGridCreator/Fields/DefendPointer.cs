namespace CustomGrid
{
    using System.Collections;
    using UnityEngine;

    public class DefendPointer:MonoBehaviour
   {
        [SerializeField] private float _speedRotate;

        public void ShowPointer(bool show)
        {
             gameObject.SetActive(show);
            if (show)
                StartCoroutine(MovingPointer());
            else
            {
                StopCoroutine(MovingPointer());
            }
        }
     
        private IEnumerator MovingPointer()
        {
            while (gameObject.activeSelf)
            {
                transform.Rotate(0, _speedRotate * Time.unscaledDeltaTime, 0);

                yield return null;
            }
        }

    }
}