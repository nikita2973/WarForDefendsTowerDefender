namespace Defend
{
    using CustomGrid;
    using System.Collections.Generic;
    using UnityEngine;

    public class DefenderFieldController : MonoBehaviour
    {
        private List<DefendField> _defendFieldList;

        [SerializeField] Transform _defenderFieldParents;

        public void ShowMeFieldsForSelect(bool show)
        {
            foreach (DefendField field in _defendFieldList)
            {
                if(field.isFree &&show)
                {
                    field.defendPointer.ShowPointer(show);
                }else if (show==false)
                {
                    field.defendPointer.ShowPointer(show);
                }
            }
            if(show)
            Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        public void AddFieldToList(List<DefendField>  gDefendField)
        {
            if (gDefendField != null)
            {
                if(_defenderFieldParents == null)_defenderFieldParents = transform;

                _defendFieldList = new List<DefendField>(gDefendField);
                foreach (DefendField field in _defendFieldList)
                {
                    field.transform.parent = _defenderFieldParents; 
                }

            }
        }


    }

}