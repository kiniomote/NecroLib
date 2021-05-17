using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Require;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Abilities;
using NecroLib.Models.Resources;
using NecroLib.Models.Localization;
using NecroLib.Models.Images;

namespace NecroLib.Models.Units.UnitBuilder
{
    public delegate IUnit UnitBuild();

    public abstract class UnitBuilder : IUnitBuilder
    {
        protected virtual SquadType SQUAD_TYPE { get; }
        protected virtual int UNIT_POWER { get; }

        protected virtual Dictionary<ResourceType, int> RESOURCES { get; }

        protected virtual Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get; }
        protected virtual Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get; }

        protected virtual List<IUnitAbility> COMMON_ABILITIES { get; }
        protected virtual List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get; }

        protected virtual DamageType DAMAGE_TYPE { get; }

        protected Dictionary<UnitLevel, UnitBuild> _builders;

        public UnitBuilder()
        {
            _builders = new Dictionary<UnitLevel, UnitBuild>()
            {
                [UnitLevel.Common] = CommonBuild,
                [UnitLevel.FirstUpgraded] = FirstUpgradedBuild,
            };
        }

        public IUnit BuildUnit(UnitLevel unitLevel)
        {
            return _builders[unitLevel].Invoke();
        }

        protected IUnit CommonBuild()
        {
            string name = LocalizationNames.COMMON_SQUAD[SQUAD_TYPE];
            IUnitPower unitPower = new UnitPower(UNIT_POWER);
            IPrice price = new Price(RESOURCES);
            IWorth worth = new Worth(price);
            ICharacteristicsSet characteristicsSet = new CharacteristicsSet(COMMON_CHARACTERISTICS, DAMAGE_TYPE);
            IUnitAbilitySet abilities = new UnitAbilitySet(COMMON_ABILITIES);
            IUnit unit = new Unit(name, unitPower, worth, characteristicsSet, abilities, SQUAD_TYPE);
            unit.IconImage = new ImagePath(ImagePaths.COMMON_SQUAD[SQUAD_TYPE], ImagePaths.ICON_IMAGE);
            return unit;
        }

        protected IUnit FirstUpgradedBuild()
        {
            string name = LocalizationNames.FIRST_UPGRADED_SQUAD[SQUAD_TYPE];
            IUnitPower unitPower = new UnitPower(UNIT_POWER);
            IPrice price = new Price(RESOURCES);
            IWorth worth = new Worth(price);
            ICharacteristicsSet characteristicsSet = new CharacteristicsSet(FIRST_UPGRADED_CHARACTERISTICS, DAMAGE_TYPE);
            IUnitAbilitySet abilities = new UnitAbilitySet(FIRST_UPGRADED_ABILITIES);
            IUnit unit = new Unit(name, unitPower, worth, characteristicsSet, abilities, SQUAD_TYPE);
            unit.IconImage = new ImagePath(ImagePaths.FIRST_UPGRADED_SQUAD[SQUAD_TYPE], ImagePaths.ICON_IMAGE);
            return unit;
        }
    }
}
