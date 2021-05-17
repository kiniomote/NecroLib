using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IAttackModifierSet
    {
        void SetTargets(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);

        void ActionsBefore();
        int ModifyMinDamage(int damage);
        int ModifyMaxDamage(int damage);
        int ModifyAttackSpeed(int attack);
        int ModifyAttack(int attack);
        void ActionsAfter();
    }
}
