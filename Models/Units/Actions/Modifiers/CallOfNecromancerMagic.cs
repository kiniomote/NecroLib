using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class CallOfNecromancerMagic : MagicModifier
    {
        public const int RAISED = 25;
        public const int PERCENT = 100;

        public const int COUNTDOWN_MODIFIER = 120;

        public CallOfNecromancerMagic(TemporaryEffect countdown) : base(countdown)
        {

        }

        public override void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int raisedPower = (unit.Unit.Power.GetPower() * unit.GetCount() * RAISED) / PERCENT;
            int powerTarget = targetUnit.Unit.Power.GetPower();
            int raisedUnits = raisedPower / powerTarget;
            int healUnit = raisedUnits * targetUnit.GetUnitCharacteristic(UnitCharacteristic.Health);
            targetUnit.Heal(healUnit);

            int countdown = ActionSpeed.BASE_SPEED * COUNTDOWN_MODIFIER;
            IUnitTemporaryEffect countdownEffect = new Countdown(unit, EffectCountdown);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(countdown, unit.Effects.RemoveEffect, countdownEffect));
        }
    }
}
