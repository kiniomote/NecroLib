using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class SteelWallAttack : AttackModifier
    {
        public const int PERCENT = 100;
        public const int CHANCE = 30;
        public const int INCREASE_DAMAGE_BY = 5;

        public override int ModifyMaxDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int modifierDamage = damage;

            Random random = new Random();
            if (random.Next(PERCENT) < CHANCE)
            {
                modifierDamage += INCREASE_DAMAGE_BY;
            }

            return modifierDamage;
        }
    }
}
