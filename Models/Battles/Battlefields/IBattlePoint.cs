using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattlePoint
    {
        IBattleUnit BattleUnit { get; }

        void MoveIn(IBattleUnit battleUnit, IBattlePoint fromPoint = null);

        int CalculateDistance(IBattlePoint battlePoint);
        int CalculateLength(IBattlePoint battlePoint);
        int GetRow();
        int GetColumn();
    }
}
