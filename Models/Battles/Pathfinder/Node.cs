using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Pathfinder
{
    public class Node : INode
    {
        public INode PreviousNode { get; set; }
        public IBattlePoint BattlePoint { get; set; }
        public int Length { get; private set; }

        public Node(IBattlePoint battlePoint, int length, INode previous = null)
        {
            BattlePoint = battlePoint;
            Length = length;
            PreviousNode = previous;
        }

        public int GetColumn()
        {
            return BattlePoint.GetColumn();
        }

        public int GetRow()
        {
            return BattlePoint.GetRow();
        }
    }
}
