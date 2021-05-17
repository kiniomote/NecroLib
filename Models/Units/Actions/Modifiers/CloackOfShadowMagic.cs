using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class CloackOfShadowMagic : MagicModifier
    {
        public const int DURATION_MODIFIER = 6;
        public const int COUNTDOWN_MODIFIER = 30;

        public CloackOfShadowMagic(TemporaryEffect countdown) : base(countdown)
        {

        }

        public override void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int duration = ActionSpeed.BASE_SPEED * DURATION_MODIFIER;
            IUnitTemporaryEffect effect = new CloackOfShadow(unit);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(duration, unit.Effects.RemoveEffect, effect));

            int countdown = ActionSpeed.BASE_SPEED * COUNTDOWN_MODIFIER;
            IUnitTemporaryEffect countdownEffect = new Countdown(unit, EffectCountdown);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(countdown, unit.Effects.RemoveEffect, countdownEffect));
        }
    }
}
