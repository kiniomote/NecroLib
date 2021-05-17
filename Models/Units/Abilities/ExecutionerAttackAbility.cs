using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Actions.Modifiers;

namespace NecroLib.Models.Units.Abilities
{
    public class ExecutionerAttackAbility : UnitAbility
    {
        public ExecutionerAttackAbility() : base(UnitAbilities.Executioner)
        {

        }

        public override void AddAttackModifierTo(List<IAttackModifier> attackModifiers)
        {
            attackModifiers.Add(new ExecutionerAttack());
        }
    }
}
