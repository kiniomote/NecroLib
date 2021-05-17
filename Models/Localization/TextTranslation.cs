using System;
using System.Collections.Generic;
using System.Linq;

namespace NecroLib.Models.Localization
{
    [Serializable]
    public class TextTranslation : ITranslation
    {
        private string _unique_name;
        private Dictionary<ILanguage, string> _translations;

        public static ITranslation FindInCollectionByName(IEnumerable<ITranslation> translations, string unique_name)
        {
            ITranslation found_translation = null;

            foreach(ITranslation translation in translations)
            {
                if (translation.GetUniqueName() == unique_name)
                {
                    found_translation = translation;
                    break;
                }
            }
            return found_translation;
        }

        public TextTranslation(string unique_name)
        {
            SetUniqueName(unique_name);
            _translations = new Dictionary<ILanguage, string>();
        }

        public string GetUniqueName()
        {
            return _unique_name;
        }

        public void SetUniqueName(string unique_name)
        {
            _unique_name = unique_name;
        }

        public void AddTranslation(ILanguage language, string translation)
        {
            if (language.ExsistInCollection(_translations.Keys))
            {
                _translations[findLanguage(language)] = translation;
            }
            else
                _translations.Add(language, translation);
        }

        public void DeleteTranslation(ILanguage language)
        {
            if (language.ExsistInCollection(_translations.Keys))
            {
                _translations.Remove(language);
            }
        }

        public string Translate(ILanguage language)
        {
            return _translations[findLanguage(language)];
        }

        public bool ExsistInCollection(IEnumerable<ICollectable> text_translations)
        {
            bool exsist = false;

            foreach (ITranslation textTranslation in text_translations)
            {
                if (textTranslation.GetUniqueName() == _unique_name)
                {
                    exsist = true;
                    break;
                }
            }
            return exsist;
        }

        private ILanguage findLanguage(ILanguage language)
        {
            ILanguage old_language = _translations.Keys.First(lang => lang.GetName() == language.GetName());
            return old_language;
        }
    }

}
