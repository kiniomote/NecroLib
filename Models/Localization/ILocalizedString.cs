using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    public interface ILocalizedString
    {
        string GetName();
        void SetName(string name, string additionalName);

        string ToString();
    }
}
