using UnityEngine;

public class TouchObsolver : MonoBehaviour
{
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragRays(Input.mousePosition);
        }
        else if (Input.touchCount > 0)
        {
            DragRays(Input.touches[0].position);
        }
        else
        {
            return;
        }
    }
    
    private void DragRays(Vector3 clickPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          
            if (hit.transform.gameObject.TryGetComponent(out ICllickingObject tGet))
            {
                tGet.OnObjectClick();
            }
        }
    }

}

public interface ICllickingObject
{
    public void OnObjectClick();
}