using System;
using System.Collections.Generic;
using System.Linq;
using NecroLib.Services.Serialization;

namespace NecroLib.Models.Localization
{
    public class LanguageChanger : ISerializable
    {
        private static List<ILanguage> _languages = new List<ILanguage>();
        private static ILanguage _current_language;

        public const string FILE_NAME = "lang.dat";

        public ILanguage GetCurrentLanguage()
        {
            return _current_language;
        }

        public List<ILanguage> GetCollectionLanguages()
        {
            return _languages;
        }

        public List<string> GetLanguagesName()
        {
            List<string> names = new List<string>();

            foreach(ILanguage language in _languages)
            {
                names.Add(language.GetName());
            }

            return names;
        }

        public void AddLanguage(ILanguage language)
        {
            _languages.Add(language);
            if (_current_language == null)
            {
                _current_language = _languages.First();
            }
        }

        public void DeleteLanguage(ILanguage language)
        {
            if (_current_language == language)
            {
                _current_language = null;
            }
            _languages.Remove(language);
        }

        public void RenameLanguage(string old_name, string new_name)
        {
            ILanguage language = _languages.First(lang => lang.GetName() == old_name);
            language.SetName(new_name);
        }

        public void ChangeCurrentLanguage(string name)
        {
            _current_language = _languages.First(lang => lang.GetName() == name);
        }

        public object Serialize()
        {
            return _languages;
        }

        public void Deserialize(object to_deserialize)
        {
            if (to_deserialize == null)
                return;
            _languages = (List<ILanguage>)to_deserialize;
        }
    }
}
