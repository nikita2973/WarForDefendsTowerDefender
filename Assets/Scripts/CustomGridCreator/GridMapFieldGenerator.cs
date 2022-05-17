namespace CustomGrid
{
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(GridController))]
    [RequireComponent(typeof(CustomGridMap))]
    public class GridMapFieldGenerator : MonoBehaviour
    {
        
        [SerializeField] private CustomGridMap _gridMap;

        [SerializeField] private Field[] _fields;
        
        [SerializeField]int enemyfieldCount = 0;
        [SerializeField] private Field[] _enemyPath;
        [Space(20)]
        [SerializeField] private GameObject _start;
     
        private List<Field> _pointForDefendBuilding;
        private GridController _controller;

        private void Awake()
        {
            ComponentControll();

            CreateFieldGrid();
        }

        public void CreateFieldGrid()
        {
          
            Field field ;
            _enemyPath = new Field[enemyfieldCount];

            for (int x = 0; x < _gridMap.columns.Length; x++)
            {
           
                for (int y = 0; y < _gridMap.columns[x].rows.Length; y++)
                {
                  int fieldSpawn=0;
                    FieldType fieldType = FieldType.DecorateField;
                    switch (_gridMap.columns[x].rows[y])
                    {
                        case -1:
                            fieldType = FieldType.DefendBuilding;
                            fieldSpawn = 1;
                            break;
                        case 0:
                            fieldType=FieldType.DecorateField;
                            fieldSpawn = 0;
                            break;
                        default:
                            fieldType=FieldType.EnemyPathField;
                            fieldSpawn = 2;
                    
                            break;
                    }
                    field = Instantiate(_fields[fieldSpawn], new Vector3(x, 0, y), Quaternion.identity, transform);
                    field.CreateField(fieldType);
             
                    switch (field.fieldType)
                    {

                        case FieldType.EnemyPathField: if (_enemyPath != null) { _enemyPath[_gridMap.columns[x].rows[y]-1]=field; } field.name = field.name + " enemy Field"; break;
                        case FieldType.DefendBuilding: if (_pointForDefendBuilding != null) { _pointForDefendBuilding.Add(field); } field.name = field.name + "Defend Field"; break;

                    }

                }

            }

            Instantiate(_start, new Vector3(_enemyPath[0].transform.position.x,0.55f, _enemyPath[0].transform.position.z), Quaternion.identity, null) ;

            if (_controller != null) _controller.GetFields(_pointForDefendBuilding,_enemyPath);

            if (!runInEditMode)
            {
                Destroy(this);
                Destroy(_gridMap);
            }
        }
        private void ComponentControll()
        {
            if (_gridMap == null) _gridMap = GetComponent<CustomGridMap>();

            if (_pointForDefendBuilding == null) _pointForDefendBuilding = new List<Field>();

            _controller = GetComponent<GridController>();
        }

    }

 
    public enum FieldType
    {
        DecorateField,
        DefendBuilding,
        EnemyPathField
    }
}