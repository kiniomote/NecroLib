using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Actions.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public class TentacleGripAbility : UnitAbility
    {
        public const int RANGE = 2;
        public const int WIDTH = 1;
        public static readonly bool? TARGET_TYPE = Battlefield.ENEMY;
        public static readonly TemporaryEffect EffectCountdown = TemporaryEffect.TentacleGripCountdown;

        public TentacleGripAbility() : base(UnitAbilities.TentacleGrip)
        {

        }

        public override TemporaryEffect? GetCountDownEffect()
        {
            return EffectCountdown;
        }

        public override void AddAdditionalActions(List<IUnitAction> unitActions, IBattleUnit battleUnit)
        {
            List<IMagicModifier> magicModifiers = new List<IMagicModifier>();
            magicModifiers.Add(new TentacleGripMagic(EffectCountdown));

            IMagicModifierSet magicModifierSet = new MagicModifierSet(RANGE, WIDTH, TARGET_TYPE, magicModifiers, EffectCountdown);
            IUnitAction unitAction = new MagicAction(battleUnit, magicModifierSet);
            unitAction.UnitAbility = this;
            unitActions.Add(unitAction);
        }
    }
}
