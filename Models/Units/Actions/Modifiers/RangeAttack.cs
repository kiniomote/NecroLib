using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class RangeAttack : AttackModifier
    {
        public const double MODIFIER = 2.0;

        public override int ModifyMinDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int modifierDamage = damage;

            if (unit.BattlePoint.CalculateDistance(targetUnit.BattlePoint) <= 1)
            {
                modifierDamage = Convert.ToInt32(Math.Round(Convert.ToDouble(modifierDamage) / MODIFIER));
            }

            return modifierDamage;
        }

        public override int ModifyMaxDamage(int damage, IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int modifierDamage = damage;

            if (unit.BattlePoint.CalculateDistance(targetUnit.BattlePoint) <= 1)
            {
                modifierDamage = Convert.ToInt32(Math.Round(Convert.ToDouble(modifierDamage) / MODIFIER));
            }

            return modifierDamage;
        }
    }
}
