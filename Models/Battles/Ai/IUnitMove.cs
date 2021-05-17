using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles.Ai
{
    public enum UnitMove
    {
        Attack=0,
        Chase=1,
        Escape=2,
        Hold=3,
    }

    public interface IUnitMove
    {
        IBattleUnitAi Unit { get; }

        double GetMovePrioprity();
        void ReleaseMove(bool changed);
    }
}
