using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Abilities
{
    public interface IUnitAbilitySet
    {
        List<IUnitAbility> GetAbilities();
        IAvailableActionSet GetActions(IBattleUnit battleUnit);
    }
}
