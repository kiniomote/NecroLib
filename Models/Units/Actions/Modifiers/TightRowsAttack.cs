using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class TightRowsAttack : AttackModifier
    {
        public const int INCREASE_COUNT = 10;
        public const int INCREASE_ATTACK_BY = 1;

        public override int ModifyAttack(int attack, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int modifierAttack = attack;

            int superiority = unit.GetCount() - targetUnit.GetCount();
            if (superiority >= INCREASE_COUNT)
            {
                modifierAttack += INCREASE_ATTACK_BY * (superiority / INCREASE_COUNT);
            }

            return modifierAttack;
        }
    }
}
