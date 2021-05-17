using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units;

namespace NecroLib.Models.Battles.Ai
{
    public class AttackMoveAi : TargetUnitMove
    {
        private static readonly List<SquadType> _rangeUnits = new List<SquadType>()
        {
            SquadType.Archer,
            SquadType.Thrower,
            SquadType.Magic,
            SquadType.Support,
        };

        private Dictionary<SquadType, double> _squadPriorities = new Dictionary<SquadType, double>
        {
            [SquadType.Support] = 115,
            [SquadType.Magic] = 110,
            [SquadType.Archer] = 105,
            [SquadType.Cavalry] = 100,
            [SquadType.Thrower] = 95,
            [SquadType.UltimateForce] = 90,
            [SquadType.SpecialForce] = 85,
            [SquadType.LightInfantry] = 80,
            [SquadType.HeavyInfantry] = 75,
        };

        public const int ATTACK_ACTION = 0;

        public const double DEFAULT_PRIORITY = 0;
        public const double ASSIST_PRIORITY = 30;
        private const double PENALTY_RANGE = 35;

        private IUnitAction _unitAction;

        public AttackMoveAi(IBattleUnitAi unit, IBattlerAi battler) : base(ATTACK_ACTION, unit, battler)
        {
            _unitAction = Unit.BattleUnit.Actions.GetAvailableActions()[ATTACK_ACTION];

            if (_rangeUnits.Contains(Unit.BattleUnit.Squad.GetSquadType()))
            {
                _squadPriorities[SquadType.HeavyInfantry] -= PENALTY_RANGE;
            }
        }

        public override double GetMovePrioprity()
        {
            double priority = 0;
            _targetUnit = null;

            List<IBattlePoint> enemies = _unitAction.PossiblePoints(_battler.Battle.Field);
            if (enemies.Count == 0)
            {
                return priority;
            }

            priority = FindBestAttackTarget(enemies);

            if (_battler.AiType == AiType.Crazy)
            {
                priority *= BattleUnitAi.AI_TYPE_FACTOR;
            }

            return priority;
        }

        private double FindBestAttackTarget(List<IBattlePoint> enemies)
        {
            double priority = DEFAULT_PRIORITY;

            double mostUnitPriority = 0;
            foreach (IBattlePoint point in enemies)
            {
                double unitPriority = UnitPriority(point.BattleUnit);
                if (unitPriority > mostUnitPriority)
                {
                    mostUnitPriority = unitPriority;
                    _targetUnit = point.BattleUnit;
                }
            }
            priority += mostUnitPriority;

            return priority;
        }

        private double UnitPriority(IBattleUnit unit)
        {
            double priority = _squadPriorities[unit.Squad.GetSquadType()];

            foreach (IBattleUnit battleUnit in _battler.Battler.GetAliveUnits())
            {
                if (battleUnit != Unit && battleUnit.Actions.GetAvailableActions()[ATTACK_ACTION].PossiblePoints(_battler.Battle.Field).Contains(unit.BattlePoint))
                {
                    priority += ASSIST_PRIORITY;
                }
            }

            return priority;
        }
    }
}
