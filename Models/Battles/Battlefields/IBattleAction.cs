using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattleAction
    {
        IUnitAction UnitAction { get; set; }
        bool? Promote();
        int GetDuration();
        int GetLeftDuration();
    }
}
