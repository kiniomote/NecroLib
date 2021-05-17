using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Units.Effects
{
    public class Stunned : UnitTemporaryEffect
    {
        public Stunned(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.Stunned);
        }

        public override bool AllowDoAction(UnitAction action)
        {
            return false;
        }
    }
}
