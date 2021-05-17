using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Units.Stats
{
    public interface ICharacteristic<T> : INameable
    {
        void Modify(T value);
        T GetValue();
    }
}
