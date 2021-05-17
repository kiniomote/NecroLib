using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Actions.Modifiers;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public class UnitAbilitySet : IUnitAbilitySet
    {
        private List<IUnitAbility> _abilities;

        public UnitAbilitySet(List<IUnitAbility> abilities)
        {
            _abilities = abilities;
        }

        public List<IUnitAbility> GetAbilities()
        {
            return _abilities;
        }

        public IAvailableActionSet GetActions(IBattleUnit battleUnit)
        {
            AddEffects(battleUnit);

            List<IAttackModifier> attackModifiers = new List<IAttackModifier>();
            List<IMoveModifier> moveModifiers = new List<IMoveModifier>();

            foreach (IUnitAbility ability in _abilities)
            {
                ability.AddAttackModifierTo(attackModifiers);
                ability.AddMoveModifierTo(moveModifiers);
            }

            List<IUnitAction> actions = new List<IUnitAction>()
            {
                new AttackAction(battleUnit, new AttackModifierSet(attackModifiers)),
                new MoveAction(battleUnit, new MoveModifierSet(moveModifiers)),
            };

            _abilities.ForEach(ability => ability.AddAdditionalActions(actions, battleUnit));

            IAvailableActionSet availableActionSet = new AvailableActionSet(actions);

            return availableActionSet;
        }

        private void AddEffects(IBattleUnit battleUnit)
        {
            _abilities.ForEach(ability => ability.AddEffects(battleUnit));
        }
    }
}
