using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Actions.Modifiers;

namespace NecroLib.Models.Units.Abilities
{
    public class PoisonAttackAbility : UnitAbility
    {
        public PoisonAttackAbility() : base(UnitAbilities.PoisonAttack)
        {

        }

        public override void AddAttackModifierTo(List<IAttackModifier> attackModifiers)
        {
            attackModifiers.Add(new PoisonAttack());
        }
    }
}
