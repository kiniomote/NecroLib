using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    public interface ILanguage : ICollectable
    {
        string GetName();
        void SetName(string name);
    }
}
