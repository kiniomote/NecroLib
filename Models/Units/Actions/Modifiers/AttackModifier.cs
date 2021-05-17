using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public abstract class AttackModifier : IAttackModifier
    {
        public virtual void ActionsBefore(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            
        }

        public virtual int ModifyAttack(int attack, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            return attack;
        }

        public virtual int ModifyAttackSpeed(int attackSpeed, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            return attackSpeed;
        }

        public virtual int ModifyMinDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            return damage;
        }

        public virtual int ModifyMaxDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            return damage;
        }

        public virtual void ActionsAfter(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {

        }
    }
}
