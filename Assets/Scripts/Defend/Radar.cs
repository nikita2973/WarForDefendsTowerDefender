namespace Defend {
    using DG.Tweening;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Radar : MonoBehaviour
    {
        [SerializeField,HideInInspector] private DefenderStatus _status;
       
        [SerializeField] private Defender _defender;
    
        [SerializeField] private float _scaleTO=0.75f;

        [SerializeField] private float _scaleSpeed;

        [SerializeField] private int _vibretion = 0;

        [SerializeField] private float _elasticity = 0;

        private float _startSize;
        private void Start()
        { 
            if(_defender != null)
            {
                _defender=transform.parent.GetComponent<Defender>();
             
            }
            if( _status != null)
            {
                _status=_defender.status;
           
            }
            _startSize = ((float)_status.attackDistance / 10)/2;
            transform.localScale=new Vector3( _startSize, _startSize, _startSize ); 
            DOTween.Init();
            Resize();
        }
        private void Resize()
        {
            _scaleTO = _startSize - _scaleTO;
            Debug.Log(_scaleTO);
            Sequence sequence = DOTween.Sequence()
             .Append(transform.DOPunchScale(new Vector3(_scaleTO,_scaleTO,_scaleTO), _scaleSpeed, _vibretion, _elasticity));
            sequence.SetLoops(-1, LoopType.Incremental);
           DOTween.Play(sequence);
           
        }


    }
}