using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Stats
{
    public enum DamageType
    {
        Melee=0,
        Range=1,
        Magic=2,
    }

    public interface IHaveDamageType
    {
        DamageType DamageType { get; }
    }
}
