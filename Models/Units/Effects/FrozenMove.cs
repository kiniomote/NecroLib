using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Units.Effects
{
    public class FrozenMove : UnitTemporaryEffect
    {
        public FrozenMove(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.FrozenMove);
        }

        public override bool AllowDoAction(UnitAction action)
        {
            return action != UnitAction.Move;
        }
    }
}
