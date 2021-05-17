using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    [Serializable]
    public class BattlePoint : IBattlePoint
    {
        [field:NonSerialized]
        public IBattleUnit BattleUnit { get; private set; }

        private int _row;
        private int _column;

        public BattlePoint(int row, int column)
        {
            _row = row;
            _column = column;
            BattleUnit = null;
        }

        public void MoveIn(IBattleUnit battleUnit, IBattlePoint fromPoint = null)
        {
            BattleUnit = battleUnit;
            BattleUnit?.Moved(this);
            if (fromPoint != null)
            {
                fromPoint.MoveIn(null);
            }
        }

        public int CalculateDistance(IBattlePoint battlePoint)
        {
            int row = Math.Abs(GetRow() - battlePoint.GetRow());
            int column = Math.Abs(GetColumn() - battlePoint.GetColumn());

            return Math.Max(row, column);
        }

        public int CalculateLength(IBattlePoint battlePoint)
        {
            int height = Math.Abs(GetRow() - battlePoint.GetRow());
            int width = Math.Abs(GetColumn() - battlePoint.GetColumn());

            return width + height;
        }

        public int GetRow()
        {
            return _row;
        }

        public int GetColumn()
        {
            return _column;
        }
    }
}
