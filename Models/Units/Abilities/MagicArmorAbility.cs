using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;

namespace NecroLib.Models.Units.Abilities
{
    public class MagicArmorAbility : UnitAbility
    {
        public MagicArmorAbility() : base(UnitAbilities.MagicArmor)
        {

        }

        public override void AddEffects(IBattleUnit battleUnit)
        {
            _ = new MagicArmor(battleUnit);
        }
    }
}
