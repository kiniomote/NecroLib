using NecroLib.Models.Battles;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Actions.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public abstract class UnitAbility : IUnitAbility
    {
        protected LocalizedString _name;
        protected LocalizedString _description;

        public IImagePath IconImage { get; set; }

        public UnitAbilities Ability { get; private set; }

        public UnitAbility(UnitAbilities ability)
        {
            Ability = ability;
            _name = new LocalizedString(LocalizationNames.UNIT_ABILITIES[Ability], LocalizationNames.NAME);
            _description = new LocalizedString(LocalizationNames.UNIT_ABILITIES[Ability], LocalizationNames.DESCRIPTION);
            IconImage = new ImagePath(ImagePaths.UNIT_ABILITIES[ability], ImagePaths.ICON_IMAGE);
        }

        public virtual void AddAdditionalActions(List<IUnitAction> unitActions, IBattleUnit battleUnit)
        {

        }

        public virtual void AddAttackModifierTo(List<IAttackModifier> attackModifiers)
        {

        }

        public virtual void AddEffects(IBattleUnit battleUnit)
        {

        }

        public virtual void AddMoveModifierTo(List<IMoveModifier> moveModifiers)
        {

        }

        public virtual TemporaryEffect? GetCountDownEffect()
        {
            return null;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public string GetDescription()
        {
            return _description.ToString();
        }
    }
}
