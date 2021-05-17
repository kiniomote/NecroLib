using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class AttackModifierSet : IAttackModifierSet
    {
        private List<IAttackModifier> _modifiers;

        private IBattleUnit _unit;
        private IBattleUnit _targetUnit;
        private IBattleCourse _battleCourse;

        public AttackModifierSet(List<IAttackModifier> modifiers)
        {
            _modifiers = modifiers;
        }

        public void SetTargets(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            _unit = unit;
            _targetUnit = targetUnit;
            _battleCourse = battleCourse;
        }

        public void ActionsBefore()
        {
            foreach (IAttackModifier modifier in _modifiers)
            {
                modifier.ActionsBefore(_unit, _targetUnit, _battleCourse);
            }
        }

        public int ModifyAttack(int attack)
        {
            int changedAttack = attack;

            foreach (IAttackModifier modifier in _modifiers)
            {
                changedAttack = modifier.ModifyAttack(changedAttack, _unit, _targetUnit, _battleCourse);
            }

            return changedAttack;
        }

        public int ModifyAttackSpeed(int attackSpeed)
        {
            int changedAttackSpeed = attackSpeed;

            foreach (IAttackModifier modifier in _modifiers)
            {
                changedAttackSpeed = modifier.ModifyAttackSpeed(changedAttackSpeed, _unit, _targetUnit, _battleCourse);
            }

            return changedAttackSpeed;
        }

        public int ModifyMinDamage(int damage)
        {
            int changedDamage = damage;

            foreach (IAttackModifier modifier in _modifiers)
            {
                changedDamage = modifier.ModifyMinDamage(changedDamage, _unit, _targetUnit, _battleCourse);
            }

            return changedDamage;
        }

        public int ModifyMaxDamage(int damage)
        {
            int changedDamage = damage;

            foreach (IAttackModifier modifier in _modifiers)
            {
                changedDamage = modifier.ModifyMaxDamage(changedDamage, _unit, _targetUnit, _battleCourse);
            }

            return changedDamage;
        }

        public void ActionsAfter()
        {
            foreach (IAttackModifier modifier in _modifiers)
            {
                modifier.ActionsAfter(_unit, _targetUnit, _battleCourse);
            }
        }
    }
}
