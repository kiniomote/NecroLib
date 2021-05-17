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
    public class MagicAction : IUnitAction
    {
        private IMagicModifierSet _magicModifierSet;

        private IBattleUnit _targetUnit;
        private IBattleUnit _unit;
        private IBattleCourse _battleCourse;

        public IUnitAbility UnitAbility { get; set; }

        public MagicAction(IBattleUnit unit, IMagicModifierSet magicModifierSet)
        {
            _unit = unit;
            _magicModifierSet = magicModifierSet;
        }

        public void Prepare(IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            _targetUnit = targetPoint.BattleUnit;
            _battleCourse = battleCourse;
            _battleCourse.AddBattleEvent(_unit, new BattleAction(ActionSpeed.BASE_SPEED, this));
        }

        public bool Realease()
        {
            if (!_unit.IsDead() && !_magicModifierSet.WithoutTargets() && !PossiblePoints(_battleCourse.GetBattlefield()).Contains(_targetUnit?.BattlePoint))
                return false;

            IUnitExecuteAction executeAction = new MagicExecuteAction(this, _unit, _magicModifierSet, _targetUnit.BattlePoint, _battleCourse);
            _battleCourse.CurrentExecuteActions.Add(new BattleExecuteAction(0, executeAction));

            return true;
        }

        public List<IBattlePoint> PossiblePoints(IBattlefield battlefield)
        {
            if (!IsEnable())
                return new List<IBattlePoint>();

            if (_magicModifierSet.WithoutTargets())
                return null;

            List<IBattlePoint> possiblePoints = battlefield.GetBattlePointsRound(_unit.BattlePoint, _magicModifierSet.GetRange(), _magicModifierSet.GetWidth(), _magicModifierSet.GetTargetType());

            return possiblePoints;
        }

        public bool IsRepeat()
        {
            return false;
        }

        public bool IsEnable()
        {
            return _unit.Effects.AllowDoAction(UnitAction.Magic) && !_unit.Effects.HasEffect(_magicModifierSet.GetEffectCountdown());
        }

        public UnitAction GetTypeUnitAction()
        {
            return UnitAction.Magic;
        }
    }
}
