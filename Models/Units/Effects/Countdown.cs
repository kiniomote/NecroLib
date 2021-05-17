using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class Countdown : UnitTemporaryEffect
    {
        public Countdown(IBattleUnit battleUnit, TemporaryEffect temporaryEffect) : base(battleUnit)
        {
            _effectType = temporaryEffect;
        }
    }
}
