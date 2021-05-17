using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items
{
    public interface IItemCharacteristic : INameable
    {
        int GetValue();
        string GetFullName();
    }
}
