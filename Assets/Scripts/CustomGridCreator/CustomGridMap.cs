namespace CustomGrid
{
    using UnityEngine;
    
    public class CustomGridMap : MonoBehaviour
    {
       
        public static int X, Y;

        public Column[] columns = new Column[X];
     
        public void Clear() {

            foreach (Field field in GetComponentsInChildren<Field>())
            {
               DestroyImmediate(field.gameObject);
            }
        }
    }
    [System.Serializable]
    public class Column
    {
        public int[] rows = new int[CustomGridMap.Y];
    }
}