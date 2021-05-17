using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units.Actions
{
    public interface IUnitExecuteAction
    {
        IBattlePoint SourceBattlePoint { get; }
        IBattlePoint TargetBattlePoint { get; }
        IBattleUnit BattleUnit { get; }
        IUnitAction UnitAction { get; }
        bool Release();
    }
}
