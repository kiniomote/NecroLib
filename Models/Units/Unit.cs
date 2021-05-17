using System;
using System.Collections.Generic;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Units.Require;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units
{
    public class Unit : IUnit
    {
        private LocalizedString _name;
        private LocalizedString _description;

        public IImagePath IconImage { get; set; }

        public IUnitPower Power { get; private set; }
        public ICharacteristicsSet Characteristics { get; private set; }
        public IUnitAbilitySet Abilities { get; private set; }

        public IWorth Worth { get; private set; }

        public SquadType SquadType { get; private set; }

        public Unit(string name, IUnitPower power, IWorth worth, ICharacteristicsSet characteristicsSet, IUnitAbilitySet abilities, SquadType squadType)
        {
            _name = new LocalizedString(name, LocalizationNames.NAME);
            _description = new LocalizedString(name, LocalizationNames.DESCRIPTION);
            Power = power;
            Worth = worth;
            Characteristics = characteristicsSet;
            Abilities = abilities;
            SquadType = squadType;
        }
        
        public string GetDescription()
        {
            return _description.ToString();
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
