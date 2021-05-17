using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IAttackModifier
    {
        void ActionsBefore(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
        int ModifyMinDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
        int ModifyMaxDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
        int ModifyAttackSpeed(int attackSpeed, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
        int ModifyAttack(int attack, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
        void ActionsAfter(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
    }
}
