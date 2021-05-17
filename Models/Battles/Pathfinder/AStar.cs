using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NecroLib.Models.Battles.Pathfinder
{
    public class AStar : IPathfinder
    {
        public IBattlePoint Start { get; set; }
        public IBattlePoint End { get; set; }
        public IBattlefield Field { get; set; }

        public List<INode> ClosedPoints { get; set; }
        public List<INode> OpenPoints { get; set; }

        public List<IBattlePoint> FindPath(IBattlePoint start, IBattlePoint end, IBattlefield battlefield)
        {
            Start = start;
            End = end;
            Field = battlefield;

            ClosedPoints = new List<INode>();
            OpenPoints = new List<INode>();

            OpenPoints.Add(new Node(start, 0));

            while (OpenPoints.Count > 0)
            {
                INode node = PopShortestNode();

                if (FoundPath(node))
                {
                    return BuildPath(node);
                }

                List<IBattlePoint> freePoints = Field.GetBattlePointsRound(node.BattlePoint, 1, 0);
                foreach (IBattlePoint free in freePoints)
                {
                    OpenPoints.Add(new Node(free, node.Length + 1, node));
                }
            }

            return new List<IBattlePoint>();
        }

        private INode PopShortestNode()
        {
            INode shortestNode = OpenPoints[0];
            int shortestLength = shortestNode.Length + CalculateLength(shortestNode.BattlePoint);

            foreach (INode node in OpenPoints)
            {
                int length = node.Length + CalculateLength(node.BattlePoint);
                if (length < shortestLength)
                {
                    shortestNode = node;
                    shortestLength = length;
                }
            }

            OpenPoints.Remove(shortestNode);
            ClosedPoints.Add(shortestNode);

            return shortestNode;
        }

        private bool FoundPath(INode node)
        {
            int range = Start.BattleUnit.GetUnitCharacteristic(UnitCharacteristic.RangeAttack);

            List<IBattlePoint> possiblePoints = Field.GetBattlePointsRound(node.BattlePoint, range, AttackAction.WIDTH_ATTACK, Battlefield.ENEMY);

            return possiblePoints.Contains(End);
        }

        private List<IBattlePoint> BuildPath(INode node)
        {
            List<IBattlePoint> path = new List<IBattlePoint>();
            INode partPath = node;

            while (partPath.PreviousNode.PreviousNode != null)
            {
                path.Add(partPath.BattlePoint);
                partPath = partPath.PreviousNode;
            }
            path.Reverse();

            return path;
        }

        private int CalculateLength(IBattlePoint battlePoint)
        {
            int width = Math.Abs(battlePoint.GetColumn() - End.GetColumn());
            int height = Math.Abs(battlePoint.GetRow() - End.GetRow());

            return width + height;
        }
    }
}
