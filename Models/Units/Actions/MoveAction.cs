using System;
using System.Collections.Generic;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Actions.Modifiers;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Abilities;
using System.Text;

namespace NecroLib.Models.Units.Actions
{
    public class MoveAction : IUnitAction
    {
        public const int RANGE_MOVE = 1;
        public const int WIDTH_MOVE = 0;

        private IMoveModifierSet _moveModifierSet;

        private IBattlePoint _targetPoint;
        private IBattleUnit _unit;
        private IBattleCourse _battleCourse;

        public IUnitAbility UnitAbility { get; set; }

        public MoveAction(IBattleUnit unit, IMoveModifierSet moveModifierSet)
        {
            _unit = unit;
            _moveModifierSet = moveModifierSet;
        }

        public void Prepare(IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            _targetPoint = targetPoint;
            _battleCourse = battleCourse;
            _moveModifierSet.SetTargets(_unit, _targetPoint, battleCourse);
            _battleCourse.AddBattleEvent(_unit, new BattleAction(ActionSpeed.CalculateTimeAction(GetMoveSpeed()), this));
        }

        public bool Realease()
        {
            if (!_unit.IsDead() && !PossiblePoints(_battleCourse.GetBattlefield()).Contains(_targetPoint))
                return false;

            IUnitExecuteAction executeAction = new MoveExecuteAction(this, _unit, _moveModifierSet, _targetPoint, _battleCourse);
            _battleCourse.CurrentExecuteActions.Add(new BattleExecuteAction(0, executeAction));

            return true;
        }

        public List<IBattlePoint> PossiblePoints(IBattlefield battlefield)
        {
            if (!IsEnable())
                return new List<IBattlePoint>();

            List<IBattlePoint> possiblePoints = battlefield.GetBattlePointsRound(_unit.BattlePoint, RANGE_MOVE, WIDTH_MOVE);

            return possiblePoints;
        }

        public bool IsRepeat()
        {
            return false;
        }

        public bool IsEnable()
        {
            return _unit.Effects.AllowDoAction(UnitAction.Move);
        }

        private int GetMoveSpeed()
        {
            int moveSpeed = _unit.GetUnitCharacteristic(UnitCharacteristic.MovementSpeed);
            return _moveModifierSet.ModifyMoveSpeed(moveSpeed);
        }

        public UnitAction GetTypeUnitAction()
        {
            return UnitAction.Move;
        }
    }
}
