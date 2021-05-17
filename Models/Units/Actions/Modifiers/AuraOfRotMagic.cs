using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class AuraOfRotMagic : MagicModifier
    {
        public const int RANGE = 1;
        public const int WIDTH = 1;

        public const int DURATION_MODIFIER = 10;
        public const int COUNTDOWN_MODIFIER = 60;

        public AuraOfRotMagic(TemporaryEffect countdown) : base(countdown)
        {
            
        }

        public override void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            List<IBattlePoint> enemies = battleCourse.GetBattlefield().GetBattlePointsRound(unit.BattlePoint, RANGE, WIDTH, Battlefield.ENEMY);
            List<IBattlePoint> friends = battleCourse.GetBattlefield().GetBattlePointsRound(unit.BattlePoint, RANGE, WIDTH, Battlefield.FRIEND);

            foreach (IBattlePoint battlePoint in enemies)
            {
                int duration = ActionSpeed.BASE_SPEED * DURATION_MODIFIER;
                IUnitTemporaryEffect effect = new AuraOfRotEnemy(battlePoint.BattleUnit);
                battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(duration, battlePoint.BattleUnit.Effects.RemoveEffect, effect));
            }

            foreach (IBattlePoint battlePoint in friends)
            {
                int duration = ActionSpeed.BASE_SPEED * DURATION_MODIFIER;
                IUnitTemporaryEffect effect = new AuraOfRotFriend(battlePoint.BattleUnit);
                battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(duration, battlePoint.BattleUnit.Effects.RemoveEffect, effect));
            }

            int countdown = ActionSpeed.BASE_SPEED * COUNTDOWN_MODIFIER;
            IUnitTemporaryEffect countdownEffect = new Countdown(unit, EffectCountdown);
            battleCourse.AddTemporaryEffect(new BattleTemporaryEffect(countdown, unit.Effects.RemoveEffect, countdownEffect));
        }
    }
}
