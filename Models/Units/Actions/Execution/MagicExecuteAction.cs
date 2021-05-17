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
    public class MagicExecuteAction : IUnitExecuteAction
    {
        public IBattlePoint TargetBattlePoint { get; private set; }
        public IBattlePoint SourceBattlePoint { get; private set; }
        public IBattleUnit BattleUnit { get; private set; }
        public IUnitAction UnitAction { get; private set; }

        private IMagicModifierSet _magicModifierSet;

        private IBattleCourse _battleCourse;

        public MagicExecuteAction(IUnitAction unitAction, IBattleUnit unit, IMagicModifierSet magicModifierSet, IBattlePoint targetBattlePoint, IBattleCourse battleCourse)
        {
            UnitAction = unitAction;
            BattleUnit = unit;
            _magicModifierSet = magicModifierSet;
            _battleCourse = battleCourse;
            TargetBattlePoint = targetBattlePoint;
            SourceBattlePoint = BattleUnit.BattlePoint;
        }

        public bool Release()
        {
            if (!_magicModifierSet.WithoutTargets() && TargetBattlePoint.BattleUnit == null)
                return false;

            _magicModifierSet.SetTargets(BattleUnit, TargetBattlePoint.BattleUnit, _battleCourse);
            Actions();
            return true;
        }

        private void Actions()
        {
            _magicModifierSet.Actions();
        }
    }
}
