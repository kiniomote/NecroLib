using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattlefield
    {
        List<IBattlePoint> BattlePoints { get; }

        IBattlePoint GetBattlePoint(int row, int column);
        List<IBattlePoint> GetBattlePoints(int minRow, int maxRow, int minColumn, int maxColumn);
        List<IBattlePoint> GetBattlePointsRound(IBattlePoint battlePoint, int range, int width, bool? targets = null);

        void SetUnit(IBattleUnit unit, int row, int column);
        int GetRows();
        int GetColumns();
    }
}
