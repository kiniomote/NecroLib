using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IMagicModifierSet
    {
        void SetTargets(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);

        void Actions();

        int GetRange();
        int GetWidth();
        TemporaryEffect GetEffectCountdown();
        bool? GetTargetType();
        bool WithoutTargets();
    }
}
