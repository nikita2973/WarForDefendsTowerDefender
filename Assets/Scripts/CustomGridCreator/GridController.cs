namespace CustomGrid
{
    using System.Collections.Generic;
    using UnityEngine;

    public class GridController : MonoBehaviour
    {
        [SerializeField] private Defend.DefenderFieldController _defenderFieldController;
      
        [Space(20)]

        private Field[] _enemyPath;

        public void GetFields(List<Field> gFieldForDefendBuildings, Field[] gEnemyPath)
        {
            if (gEnemyPath != null)
                _enemyPath=gEnemyPath;

            if (gFieldForDefendBuildings != null)
            {
                List<DefendField> defendFields = new List<DefendField>();
               foreach (DefendField f in gFieldForDefendBuildings)
                {
                        defendFields.Add(f);
                }
                _defenderFieldController.AddFieldToList( defendFields);
            }
        }

        public Queue<Field> GenerateQueueForEnemy(bool startFromFirstElement)
        {
            Field start, end;

            if (startFromFirstElement)
            {
                start = _enemyPath[0];

                end = _enemyPath[_enemyPath.Length - 1];
            }
            else
            {
                start = _enemyPath[_enemyPath.Length - 1];

                end = _enemyPath[0];
            }
           

            if (start == null || end == null || _enemyPath == null) return null;

            Queue<Field> fieldQueueEnemy = new Queue<Field>();

            foreach(Field field in _enemyPath)
            {
                fieldQueueEnemy.Enqueue(field);
            }

            if (fieldQueueEnemy.Peek() != start)
            {
                for (int i = 0; i < fieldQueueEnemy.Count; i++)
                {
                    fieldQueueEnemy.Enqueue(fieldQueueEnemy.Dequeue());
                }
            }

            return fieldQueueEnemy;
        }

    }
}