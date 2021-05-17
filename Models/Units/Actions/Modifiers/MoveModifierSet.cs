using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class MoveModifierSet : IMoveModifierSet
    {
        private List<IMoveModifier> _modifiers;

        private IBattleUnit _unit;
        private IBattlePoint _targetPoint;
        private IBattleCourse _battleCourse;

        public MoveModifierSet(List<IMoveModifier> modifiers)
        {
            _modifiers = modifiers;
        }

        public void SetTargets(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            _unit = unit;
            _targetPoint = targetPoint;
            _battleCourse = battleCourse;
        }

        public void ActionsBefore()
        {
            foreach (IMoveModifier modifier in _modifiers)
            {
                modifier.ActionsBefore(_unit, _targetPoint, _battleCourse);
            }
        }

        public int ModifyMoveSpeed(int moveSpeed)
        {
            int changedMoveSpeed = moveSpeed;

            foreach (IMoveModifier modifier in _modifiers)
            {
                changedMoveSpeed = modifier.ModifyMoveSpeed(changedMoveSpeed, _unit, _targetPoint, _battleCourse);
            }

            return changedMoveSpeed;
        }

        public void ActionsAfter()
        {
            foreach (IMoveModifier modifier in _modifiers)
            {
                modifier.ActionsAfter(_unit, _targetPoint, _battleCourse);
            }
        }
    }
}
