using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Localization;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Actions.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public class AuraOfRotAbility : UnitAbility
    {
        public static readonly bool? TARGET_TYPE = null;
        public const bool WITHOUT_TARGET = true;
        public static readonly TemporaryEffect EffectCountdown = TemporaryEffect.AuraOfRotCountdown;

        public AuraOfRotAbility() : base(UnitAbilities.AuraOfRot)
        {

        }

        public override TemporaryEffect? GetCountDownEffect()
        {
            return EffectCountdown;
        }

        public override void AddAdditionalActions(List<IUnitAction> unitActions, IBattleUnit battleUnit)
        {
            List<IMagicModifier> magicModifiers = new List<IMagicModifier>();
            magicModifiers.Add(new AuraOfRotMagic(EffectCountdown));

            IMagicModifierSet magicModifierSet = new MagicModifierSet(0, 0, TARGET_TYPE, magicModifiers, EffectCountdown, WITHOUT_TARGET);
            IUnitAction unitAction = new MagicAction(battleUnit, magicModifierSet);
            unitAction.UnitAbility = this;
            unitActions.Add(unitAction);
        }
    }
}
