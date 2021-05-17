using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class TentacleGripMagic : MagicModifier
    {
        public const int MIN_DAMAGE = 60;
        public const int MAX_DAMAGE = 75;
        public const int DURATION_MODIFIER = 2;
        public const int COUNTDOWN_MODIFIER = 22;

        public TentacleGripMagic(TemporaryEffect countdown) : base(countdown)
        {

        }

        public override void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            int damage = Damage.GetRandomDamage(MIN_DAMAGE, MAX_DAMAGE) * unit.GetCount();
            int attack = unit.GetUnitCharacteristic(UnitCharacteristic.Attack);
            DamageType damageType = DamageType.Magic;
            targetUnit.ApplyDamage(damage, attack, damageType);

            int duration = ActionSpeed.BASE_SPEED * DURATION_MODIFIER;
            IUnitTemporaryEffect effect = new Stunned(targetUnit);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(duration, targetUnit.Effects.RemoveEffect, effect));

            int countdown = ActionSpeed.BASE_SPEED * COUNTDOWN_MODIFIER;
            IUnitTemporaryEffect countdownEffect = new Countdown(unit, EffectCountdown);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(countdown, unit.Effects.RemoveEffect, countdownEffect));
        }
    }
}
