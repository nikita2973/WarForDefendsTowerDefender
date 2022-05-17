namespace GameUI
{
    using UnityEngine;
    [System.Serializable]
    public class WordTranslate
    {
        [SerializeField] UDictionary<Language,string> _translate;
        public UDictionary<Language,string> translate=>_translate;
    }
}