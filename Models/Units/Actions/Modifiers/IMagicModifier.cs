using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IMagicModifier
    {
        void Actions(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse);
    }
}
