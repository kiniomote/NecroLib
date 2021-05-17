using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class ExecutionerAttack : AttackModifier
    {
        public const int INCREASE_ATTACK_BY = 25;

        public override int ModifyAttack(int attack, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int modifierAttack = attack;

            int died = targetUnit.GetSize() - targetUnit.GetCount();
            if (died >= targetUnit.GetCount())
            {
                modifierAttack += INCREASE_ATTACK_BY;
            }

            return modifierAttack;
        }
    }
}
