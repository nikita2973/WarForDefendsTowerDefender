namespace GameUI
{
    using UnityEngine;

    public class UpScrollView : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.position=new Vector3 (transform.position.x, transform.position.y-2000, transform.position.z);  
        }
    }
}