using System;
using System.Collections.Generic;
using System.Linq;
using NecroLib.Services.Serialization;

namespace NecroLib.Models.Localization
{
    public class Dictionary : ISerializable
    {
        public const string FILE_NAME = "dict.dat";
        private const string DEFAULT_TEXT = "MBF";

        private static List<ITranslation> _dictionary = new List<ITranslation>();

        private LanguageChanger _languageChanger = new LanguageChanger();
        
        public string Translate(string name_text, string name_language = null)
        {
            ITranslation translation = _dictionary.FirstOrDefault(trans => trans.GetUniqueName() == name_text);

            if (translation == null)
                return "Not found!";

            if (name_language != null)
                return translation.Translate(new Language(name_language));

            return translation.Translate(_languageChanger.GetCurrentLanguage());
        }

        public bool AddLanguage(string name_language)
        {
            ILanguage language = new Language(name_language);
            if (language.ExsistInCollection(_languageChanger.GetCollectionLanguages()))
                return false;
            _languageChanger.AddLanguage(language);
            AddLanguageToTranslations(language);
            return true;
        }

        public bool AddTranslation(string name_text)
        {
            ITranslation textTranslation = new TextTranslation(name_text);
            if (textTranslation.ExsistInCollection(_dictionary))
                return false;
            _dictionary.Add(textTranslation);
            AddLanguagesToTranslation(textTranslation);
            return true;
        }

        public bool EditLanguageName(string old_name_language, string new_name_language)
        {
            ILanguage language = new Language(old_name_language);
            if (!language.ExsistInCollection(_languageChanger.GetCollectionLanguages()))
                return false;
            _languageChanger.RenameLanguage(old_name_language, new_name_language);
            return true;
        }

        public bool EditTranslationName(string old_name_translation, string new_name_translation)
        {
            ITranslation textTranslation = new TextTranslation(old_name_translation);
            if (!textTranslation.ExsistInCollection(_dictionary))
                return false;
            textTranslation = _dictionary.First(trans => trans.GetUniqueName() == old_name_translation);
            textTranslation.SetUniqueName(new_name_translation);
            return true;
        }

        public bool DeleteLanguage(string name_language)
        {
            ILanguage language = new Language(name_language);
            if (!language.ExsistInCollection(_languageChanger.GetCollectionLanguages()))
                return false;
            language = _languageChanger.GetCollectionLanguages().First(lang => lang.GetName() == name_language);
            _languageChanger.DeleteLanguage(language);
            DeleteLanguageInTranslations(language);
            return true;
        }

        public bool DeleteTranslation(string name_translation)
        {
            ITranslation textTranslation = new TextTranslation(name_translation);
            if (!textTranslation.ExsistInCollection(_dictionary))
                return false;
            textTranslation = _dictionary.First(trans => trans.GetUniqueName() == name_translation);
            _dictionary.Remove(textTranslation);
            return true;
        }

        public bool EditTranslationByLanguage(string name_translation, string name_language, string translation)
        {
            ITranslation textTranslation = new TextTranslation(name_translation);
            ILanguage language = new Language(name_language);
            if (!language.ExsistInCollection(_languageChanger.GetCollectionLanguages()) || !textTranslation.ExsistInCollection(_dictionary))
                return false;
            textTranslation = _dictionary.First(trans => trans.GetUniqueName() == name_translation);
            language = _languageChanger.GetCollectionLanguages().First(lang => lang.GetName() == name_language);
            textTranslation.AddTranslation(language, translation);
            return true;
        }

        public List<ITranslation> GetTranslations()
        {
            return _dictionary;
        }

        public List<ILanguage> GetLanguages()
        {
            return _languageChanger.GetCollectionLanguages();
        }

        private void AddLanguagesToTranslation(ITranslation translation)
        {
            foreach (ILanguage language in _languageChanger.GetCollectionLanguages())
            {
                translation.AddTranslation(language, DEFAULT_TEXT);
            }
        }

        private void AddLanguageToTranslations(ILanguage language)
        {
            foreach (ITranslation textTranslation in _dictionary)
            {
                textTranslation.AddTranslation(language, DEFAULT_TEXT);
            }
        }

        private void DeleteLanguageInTranslations(ILanguage language)
        {
            foreach (ITranslation translation in _dictionary)
            {
                translation.DeleteTranslation(language);
            }
        }

        public object Serialize()
        {
            return _dictionary;
        }

        public void Deserialize(object to_deserialize)
        {
            if (to_deserialize == null)
                return;
            _dictionary = (List<ITranslation>)to_deserialize;
        }
    }
}
