using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    public interface ITranslation : ICollectable
    {
        string GetUniqueName();

        void SetUniqueName(string unique_name);

        void AddTranslation(ILanguage language, string translation);

        void DeleteTranslation(ILanguage language);

        string Translate(ILanguage language);
    }
}
