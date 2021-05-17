using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions.Modifiers;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units.Actions
{
    public class AttackAction : IUnitAction
    {
        public const int WIDTH_ATTACK = 1;
        public const int FLIGHT_COEFFICIENT = 1;

        private IAttackModifierSet _attackModifierSet;

        private IBattleUnit _targetUnit;
        private IBattleUnit _unit;
        private IBattleCourse _battleCourse;

        public IUnitAbility UnitAbility { get; set; }

        private bool _repeat = true;

        public AttackAction(IBattleUnit unit, IAttackModifierSet attackModifierSet)
        {
            _unit = unit;
            _attackModifierSet = attackModifierSet;
        }

        public void Prepare(IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            _targetUnit = targetPoint.BattleUnit;
            _battleCourse = battleCourse;
            _repeat = true;
            _attackModifierSet.SetTargets(_unit, _targetUnit, battleCourse);
            _battleCourse.AddBattleEvent(_unit, new BattleAction(ActionSpeed.CalculateTimeAction(GetAttackSpeed()), this));
        }

        public bool Realease()
        {
            if (!_unit.IsDead() && !PossiblePoints(_battleCourse.GetBattlefield()).Contains(_targetUnit?.BattlePoint))
            {
                _repeat = false;
                return false;
            }

            int distance = _unit.BattlePoint.CalculateDistance(_targetUnit.BattlePoint);
            int speed = distance > 1 ? distance * FLIGHT_COEFFICIENT : 0;
            IUnitExecuteAction executeAction = new AttackExecuteAction(this, _unit, _attackModifierSet, _targetUnit.BattlePoint, _battleCourse);
            _battleCourse.CurrentExecuteActions.Add(new BattleExecuteAction(speed * _unit.GetUnitCharacteristic(UnitCharacteristic.FlightSpeed), executeAction));

            return true;
        }

        public List<IBattlePoint> PossiblePoints(IBattlefield battlefield)
        {
            if (!IsEnable())
                return new List<IBattlePoint>();

            int range = _unit.GetUnitCharacteristic(UnitCharacteristic.RangeAttack);

            List<IBattlePoint> possiblePoints = battlefield.GetBattlePointsRound(_unit.BattlePoint, range, WIDTH_ATTACK, Battlefield.ENEMY);

            return possiblePoints;
        }

        public bool IsRepeat()
        {
            return _repeat;
        }

        public bool IsEnable()
        {
            return _unit.Effects.AllowDoAction(UnitAction.Attack);
        }

        private int GetAttackSpeed()
        {
            int attackSpeed = _unit.GetUnitCharacteristic(UnitCharacteristic.AttackSpeed);
            return _attackModifierSet.ModifyAttackSpeed(attackSpeed);
        }

        public UnitAction GetTypeUnitAction()
        {
            return UnitAction.Attack;
        }
    }
}
