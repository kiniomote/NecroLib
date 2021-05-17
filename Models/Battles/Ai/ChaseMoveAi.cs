using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles.Pathfinder;
using NecroLib.Models.Units;

namespace NecroLib.Models.Battles.Ai
{
    public class ChaseMoveAi : TargetPointUnitMove
    {
        private Dictionary<SquadType, double> _squadPriorities = new Dictionary<SquadType, double>
        {
            [SquadType.Support] = 90,
            [SquadType.Magic] = 90,
            [SquadType.Archer] = 90,
            [SquadType.Thrower] = 90,
            [SquadType.Cavalry] = 85,
            [SquadType.UltimateForce] = 80,
            [SquadType.SpecialForce] = 79,
            [SquadType.LightInfantry] = 78,
            [SquadType.HeavyInfantry] = 75,
        };

        public ChaseMoveAi(IBattleUnitAi unit, IBattlerAi battler) : base(unit, battler)
        {

        }

        public override double GetMovePrioprity()
        {
            double priority = 0;
            _targetBattlePoint = null;

            if (_battler.Tactic == BattlerTactic.Defense)
            {
                return priority;
            }

            priority = FindMostPriorityEnemy();

            if (_battler.AiType == AiType.Coward)
            {
                priority *= BattleUnitAi.AI_TYPE_FACTOR;
            }

            return priority;
        }

        private double FindMostPriorityEnemy()
        {
            double priority = 0;
            double mostPriority = 0;
            IBattleUnit mostPriorityEnemy = null;
            List<IBattlePoint> mostPriorityPath = new List<IBattlePoint>();

            foreach (IBattleUnit enemy in _battler.Battle.Attacker.GetAliveUnits())
            {
                IPathfinder pathfinder = new AStar();
                List<IBattlePoint> path = pathfinder.FindPath(Unit.BattleUnit.BattlePoint, mostPriorityEnemy.BattlePoint, _battler.Battle.Field);
                double enemyPriority = CalculateUnitPriority(enemy, path.Count);
                if (enemyPriority > mostPriority)
                {
                    mostPriority = enemyPriority;
                    mostPriorityEnemy = enemy;
                    mostPriorityPath = path;
                }
            }

            if (mostPriorityEnemy != null && mostPriorityPath.Count > 1)
            {
                _targetBattlePoint = mostPriorityPath[0];
                priority = mostPriority;
            }

            return priority;
        }

        private double CalculateUnitPriority(IBattleUnit unit, int length)
        {
            double unitPriority = _squadPriorities[unit.Squad.GetSquadType()] / length;
            return unitPriority;
        }
    }
}
