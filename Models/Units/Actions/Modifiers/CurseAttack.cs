using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class CurseAttack : AttackModifier
    {
        public const int DURATION_MODIFIER = 2;

        public override void ActionsAfter(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int duration = ActionSpeed.BASE_SPEED * DURATION_MODIFIER;
            IUnitTemporaryEffect effect = new Curse(targetUnit);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(duration, targetUnit.Effects.RemoveEffect, effect));
        }
    }
}
