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
    public class MoveExecuteAction : IUnitExecuteAction
    {
        public const int RANGE_MOVE = 1;
        public const int WIDTH_MOVE = 0;

        public IBattlePoint TargetBattlePoint { get; private set; }
        public IBattlePoint SourceBattlePoint { get; private set; }
        public IBattleUnit BattleUnit { get; private set; }
        public IUnitAction UnitAction { get; private set; }

        private IMoveModifierSet _moveModifierSet;

        private IBattleCourse _battleCourse;

        public MoveExecuteAction(IUnitAction unitAction, IBattleUnit unit, IMoveModifierSet moveModifierSet, IBattlePoint targetBattlePoint, IBattleCourse battleCourse)
        {
            UnitAction = unitAction;
            BattleUnit = unit;
            _moveModifierSet = moveModifierSet;
            _battleCourse = battleCourse;
            TargetBattlePoint = targetBattlePoint;
            SourceBattlePoint = BattleUnit.BattlePoint;
        }

        public bool Release()
        {
            IBattleUnit target = TargetBattlePoint.BattleUnit;
            if (target != null)
                return false;

            _moveModifierSet.SetTargets(BattleUnit, TargetBattlePoint, _battleCourse);
            ActionsBefore();

            TargetBattlePoint.MoveIn(BattleUnit, BattleUnit.BattlePoint);

            ActionsAfter();
            return true;
        }

        private void ActionsBefore()
        {
            _moveModifierSet.ActionsBefore();
        }

        private void ActionsAfter()
        {
            _moveModifierSet.ActionsAfter();
        }
    }
}
