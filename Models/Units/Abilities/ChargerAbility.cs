using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Actions.Modifiers;

namespace NecroLib.Models.Units.Abilities
{
    public class ChargerAbility : UnitAbility
    {
        public ChargerAbility() : base(UnitAbilities.Charger)
        {

        }

        public override void AddAttackModifierTo(List<IAttackModifier> attackModifiers)
        {
            attackModifiers.Add(new ChargerAttack());
        }

        public override void AddMoveModifierTo(List<IMoveModifier> moveModifiers)
        {
            moveModifiers.Add(new ChargerMove());
        }
    }
}
