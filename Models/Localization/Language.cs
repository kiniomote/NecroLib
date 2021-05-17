using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    [Serializable]
    public class Language : ILanguage
    {
        private string _name;

        public Language(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public bool ExsistInCollection(IEnumerable<ICollectable> languages)
        {
            bool exsist = false;

            foreach(ILanguage language in languages)
            {
                if (language.GetName() == _name)
                {
                    exsist = true;
                    break;
                }
            }

            return exsist;
        }
    }
}
