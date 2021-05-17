using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public abstract class MagicModifier : IMagicModifier
    {
        public TemporaryEffect EffectCountdown;

        public MagicModifier(TemporaryEffect countdown)
        {
            EffectCountdown = countdown;
        }

        public virtual void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            
        }
    }
}
