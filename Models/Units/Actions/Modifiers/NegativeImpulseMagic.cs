using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class NegativeImpulseMagic : MagicModifier
    {
        public const int RANGE = 1;
        public const int WIDTH = 0;

        public const int MIN_DAMAGE = 200;
        public const int MAX_DAMAGE = 250;

        public const int COUNTDOWN_MODIFIER = 32;

        public NegativeImpulseMagic(TemporaryEffect countdown) : base(countdown)
        {

        }

        public override void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            List<IBattlePoint> enemies = battleCourse.GetBattlefield().GetBattlePointsRound(unit.BattlePoint, RANGE, WIDTH, Battlefield.ENEMY);

            foreach (IBattlePoint battlePoint in enemies)
            {
                int damage = Damage.GetRandomDamage(MIN_DAMAGE, MAX_DAMAGE) * unit.GetCount();
                int attack = unit.GetUnitCharacteristic(UnitCharacteristic.Attack);
                DamageType damageType = DamageType.Magic;
                int doneDamage = battlePoint.BattleUnit.ApplyDamage(damage, attack, damageType);
                unit.Heal(doneDamage);
            }

            int countdown = ActionSpeed.BASE_SPEED * COUNTDOWN_MODIFIER;
            IUnitTemporaryEffect countdownEffect = new Countdown(unit, EffectCountdown);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(countdown, unit.Effects.RemoveEffect, countdownEffect));
        }
    }
}
