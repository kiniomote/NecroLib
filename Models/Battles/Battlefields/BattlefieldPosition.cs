using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    [Serializable]
    public class BattlefieldPosition : IBattlefieldPosition
    {
        private int _rows;
        private int _columns;

        public List<IBattlePoint> SquadPositions { get; private set; }

        public BattlefieldPosition(List<IBattlePoint> squadPositions, int columns, int rows)
        {
            SquadPositions = squadPositions;
            _columns = columns;
            _rows = rows;
        }

        public int GetColumns()
        {
            return _columns;
        }

        public int GetRows()
        {
            return _rows;
        }
    }
}
