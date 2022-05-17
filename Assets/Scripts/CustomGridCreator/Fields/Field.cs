namespace CustomGrid
{
    using UnityEngine;
    [ExecuteInEditMode]
    public class Field : MonoBehaviour
    {
        public FieldType fieldType { get; private set; }
        public bool isFree;
       
        public void CreateField(FieldType fieldType)
        {
            gameObject.name = $"{transform.position.x}, {transform.position.z}";

            if (runInEditMode && fieldType == FieldType.EnemyPathField)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }

            isFree = true;
            this.fieldType = fieldType;
        }
      
    }
}