using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units;

namespace NecroLib.Models.Battles.Ai
{
    public class EscapeMoveAi : TargetPointUnitMove
    {
        private int AROUND_RANGE = 1;
        private int AROUND_WIDTH = 1;

        private readonly List<SquadType> _escapeable = new List<SquadType>()
        {
            SquadType.Archer,
            SquadType.Support,
            SquadType.Magic,
            SquadType.Thrower,
        };

        private readonly Dictionary<int, int> _rangeAlliesPriority = new Dictionary<int, int>()
        {
            [3] = 150,
            [4] = 115,
            [5] = 80,
            [6] = 60,
        };

        public EscapeMoveAi(IBattleUnitAi unit, IBattlerAi battler) : base(unit, battler)
        {

        }

        public override double GetMovePrioprity()
        {
            double priority = 0;

            if (!_escapeable.Contains(Unit.BattleUnit.Squad.GetSquadType()))
            {
                return priority;
            }

            List<IBattlePoint> enemiesAround = _battler.Battle.Field.GetBattlePointsRound(Unit.BattleUnit.BattlePoint, AROUND_RANGE, AROUND_WIDTH, Battlefield.ENEMY);
            List<IBattlePoint> possibleEscape = _battler.Battle.Field.GetBattlePointsRound(Unit.BattleUnit.BattlePoint, MoveAction.RANGE_MOVE, MoveAction.WIDTH_MOVE);

            if (enemiesAround.Count == 0 || possibleEscape.Count == 0)
            {
                return priority;
            }

            priority = FindBetterEscapePoint(possibleEscape);

            if (_battler.AiType == AiType.Coward)
            {
                priority *= BattleUnitAi.AI_TYPE_FACTOR;
            }

            return priority;
        }

        private double FindBetterEscapePoint(List<IBattlePoint> possibleEscape)
        {
            double priority = 0;
            double mostPriority = 10000;
            IBattlePoint mostPriorityMovePoint = null;

            foreach (IBattlePoint point in possibleEscape)
            {
                double pointPriority = 0;
                foreach (IBattleUnit unit in _battler.Battle.Defender.GetAliveUnits())
                {
                    pointPriority += Unit.BattleUnit.BattlePoint.CalculateLength(unit.BattlePoint);
                }

                if (pointPriority == 0)
                    continue;

                pointPriority /= _battler.Battle.Defender.GetAliveUnits().Count;

                if (mostPriority > pointPriority)
                {
                    mostPriority = pointPriority;
                    mostPriorityMovePoint = point;
                }
            }

            if (mostPriorityMovePoint != null)
            {
                _targetBattlePoint = mostPriorityMovePoint;
                priority = CalculateEscapePriority(mostPriority);
            }

            return priority;
        }

        private int CalculateEscapePriority(double priority)
        {
            foreach (var rangePriority in _rangeAlliesPriority)
            {
                if (priority <= rangePriority.Key)
                {
                    return rangePriority.Value;
                }
            }

            return 0;
        }
    }
}
