using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    [Serializable]
    public class LocalizedString : ILocalizedString
    {
        private string _name;
        private string _uniqueName;

        private static readonly Dictionary _dictionary = new Dictionary();

        public LocalizedString(string name, string additionalName = "")
        {
            _uniqueName = name;
            _name = name + additionalName;
        }

        public string GetName()
        {
            return _uniqueName;
        }

        public void SetName(string name, string additionalName = "")
        {
            _uniqueName = name;
            _name = name + additionalName;
        }

        public override string ToString()
        {
            return _dictionary.Translate(_name);
        }
    }
}
