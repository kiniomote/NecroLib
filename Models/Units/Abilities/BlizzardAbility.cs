﻿using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Actions.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public class BlizzardAbility : UnitAbility
    {
        public const int RANGE = 5;
        public const int WIDTH = 1;
        public static readonly bool? TARGET_TYPE = Battlefield.ENEMY;
        public static readonly TemporaryEffect EffectCountdown = TemporaryEffect.BlizzardCountdown;

        public BlizzardAbility() : base(UnitAbilities.Blizzard)
        {

        }

        public override TemporaryEffect? GetCountDownEffect()
        {
            return EffectCountdown;
        }

        public override void AddAdditionalActions(List<IUnitAction> unitActions, IBattleUnit battleUnit)
        {
            List<IMagicModifier> magicModifiers = new List<IMagicModifier>();
            magicModifiers.Add(new BlizzardMagic(EffectCountdown));

            IMagicModifierSet magicModifierSet = new MagicModifierSet(RANGE, WIDTH, TARGET_TYPE, magicModifiers, EffectCountdown);
            IUnitAction unitAction = new MagicAction(battleUnit, magicModifierSet);
            unitAction.UnitAbility = this;
            unitActions.Add(unitAction);
        }
    }
}
