using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;

namespace NecroLib.Models.Units.Abilities
{
    public class LiveShieldAbility : UnitAbility
    {
        public LiveShieldAbility() : base(UnitAbilities.LiveShield)
        {

        }

        public override void AddEffects(IBattleUnit battleUnit)
        {
            _ = new LiveShield(battleUnit);
        }
    }
}
