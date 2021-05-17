using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Units.Stats
{
    public interface IActionSpeed : INameable
    {
        void Modify(int percent);
        int GetTime();
        int GetModifier();
    }
}
