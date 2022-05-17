namespace CustomGrid
{
    using UnityEditor;
    using UnityEngine;
    [CustomEditor(typeof(CustomGridMap))]
    public class CustomInspectorGrid : Editor
    {
        private CustomGridMap _gridMap3d;

        private void OnEnable()
        {

            if (_gridMap3d == null)
                _gridMap3d = target as CustomGridMap;
        }


        public override void OnInspectorGUI()
        {

            EditorGUILayout.TextField($"{_gridMap3d.columns.Length},{_gridMap3d.columns[0].rows.Length} ");
            CustomGridMap.X = EditorGUILayout.IntField(CustomGridMap.X);
            CustomGridMap.Y = EditorGUILayout.IntField(CustomGridMap.Y);
            UpdatePlatform();
            if (GUILayout.Button("Generation"))
            {
                _gridMap3d.gameObject.GetComponent<GridMapFieldGenerator>().CreateFieldGrid();

            }
            if (GUILayout.Button("Clear"))
            {
                _gridMap3d.Clear();

            }
        }

        private void UpdatePlatform()
        {
            EditorGUILayout.BeginHorizontal();
            for (int y = 0; y < CustomGridMap.Y; y++)
            {

                EditorGUILayout.BeginVertical();
                for (int x = 0; x < CustomGridMap.X; x++)
                {
                    try
                    {
                        _gridMap3d.columns[x].rows[y] = EditorGUILayout.IntField(_gridMap3d.columns[x].rows[y]);
                    }
                    catch
                    {

                    }
                }
                EditorGUILayout.EndVertical();

            }
            EditorGUILayout.EndHorizontal();
        }
    }
}