using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Units.Stats
{
    public interface IDamage : INameable, IHaveDamageType
    {
        int GetDamage();
        int GetMinDamage();
        int GetMaxDamage();

        void ModifyMinDamage(int value);
        void ModifyMaxDamage(int value);
    }
}
