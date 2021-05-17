using NecroLib.Models.Units.Actions.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public class RangeAttackAbility : UnitAbility
    {
        public RangeAttackAbility() : base(UnitAbilities.RangeAttack)
        {

        }

        public override void AddAttackModifierTo(List<IAttackModifier> attackModifiers)
        {
            attackModifiers.Add(new RangeAttack());
        }
    }
}
