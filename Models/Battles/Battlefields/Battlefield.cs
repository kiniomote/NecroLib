using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    public class Battlefield : IBattlefield
    {
        public const int FIRST_ROW = 0;
        public const int FIRST_COLUMN = 0;
        public const int COLUMNS = 11;
        public const int ROWS = 8;

        public const bool ENEMY = true;
        public const bool FRIEND = false;

        private int _rows;
        private int _columns;

        public List<IBattlePoint> BattlePoints { get; private set; }

        public Battlefield(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            BattlePoints = new List<IBattlePoint>();
            InitBattlePoints();
        }

        public IBattlePoint GetBattlePoint(int row, int column)
        {
            return BattlePoints.Find(battlePoint => battlePoint.GetRow() == row && battlePoint.GetColumn() == column);
        }

        public List<IBattlePoint> GetBattlePoints(int minRow, int maxRow, int minColumn, int maxColumn)
        {
            return BattlePoints.FindAll(battlePoint => battlePoint.GetRow() >= minRow && battlePoint.GetRow() <= maxRow &&
                battlePoint.GetColumn() >= minColumn && battlePoint.GetColumn() <= maxColumn);
        }

        public List<IBattlePoint> GetBattlePointsRound(IBattlePoint battlePoint, int range, int width, bool? targets = null)
        {
            List<IBattlePoint> possiblePoints = new List<IBattlePoint>();

            int startRow = battlePoint.GetRow();
            int startColumn = battlePoint.GetColumn();

            int columnWidth = width;
            for (int row = startRow - range; row <= startRow + range; row++)
            {
                if (row >= FIRST_ROW && row < GetRows())
                {
                    for (int column = startColumn - columnWidth; column <= startColumn + columnWidth; column++)
                    {
                        if (column < FIRST_COLUMN || column >= GetColumns() || (row == startRow && column == startColumn))
                            continue;
                        IBattlePoint toAdd = GetBattlePoint(row, column);
                        if (IsValid(toAdd, targets, battlePoint.BattleUnit) && !possiblePoints.Contains(toAdd))
                        {
                            possiblePoints.Add(toAdd);
                        }
                    }
                }

                columnWidth += (row < startRow ? 1 : -1);
                if (row == startRow - 1)
                    columnWidth -= width;
                if (row == startRow)
                    columnWidth += width;
            }

            return possiblePoints;
        }

        public void SetUnit(IBattleUnit unit, int row, int column)
        {
            GetBattlePoint(row, column).MoveIn(unit);
        }

        public int GetRows()
        {
            return _rows;
        }

        public int GetColumns()
        {
            return _columns;
        }

        private bool IsValid(IBattlePoint battlePoint, bool? target, IBattleUnit battleUnit)
        {
            if (target == null)
                return battlePoint.BattleUnit == null;
            return battlePoint.BattleUnit != null ? battleUnit.IsEnemy(battlePoint.BattleUnit) == target : false;
        }

        private void InitBattlePoints()
        {
            BattlePoints.Clear();
            for (int row = FIRST_ROW; row < _rows; row++)
            {
                for (int column = FIRST_COLUMN; column < _columns; column++)
                {
                    BattlePoints.Add(new BattlePoint(row, column));
                }
            }
        }
    }
}
