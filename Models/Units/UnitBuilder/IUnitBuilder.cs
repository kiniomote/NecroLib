using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;

namespace NecroLib.Models.Units.UnitBuilder
{
    public interface IUnitBuilder
    {
        IUnit BuildUnit(UnitLevel unitLevel);
    }
}
