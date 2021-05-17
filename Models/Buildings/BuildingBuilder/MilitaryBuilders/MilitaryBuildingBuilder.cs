using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using NecroLib.Models.Images;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public class MilitaryBuildingBuilder : BuildingBuilder, IMilitaryBuildingBuilder
    {
        protected Dictionary<int, int> _unitPowerPerLevel;

        public static readonly Dictionary<int, int> DEFAULT_UNIT_POWER_PER_LEVEL = new Dictionary<int, int>()
        {
            [1] = 100,
            [2] = 200,
            [3] = 300,
            [4] = 400,
            [5] = 500,
            [6] = 600,
            [7] = 900,
            [8] = 1200,
        };

        protected virtual Military MILITARY { get; }

        protected virtual UnitLevel UNIT_LEVEL { get; }

        protected virtual List<SquadType> SQUADS { get; }

        public MilitaryBuildingBuilder()
        {
            FillData(DEFAULT_MAX_IMPROVEMENTS, DEFAULT_MILITARY_BASE_PRICES, DEFAULT_MILITARY_INCREMENT_PRICES);
            FillUnitPower(DEFAULT_UNIT_POWER_PER_LEVEL);
        }

        public MilitaryBuilding BuildMilitaryBuilding(int level, int numberUpgrades)
        {
            bool builded = numberUpgrades != 0;
            string name = LocalizationNames.MILITARY_BUILDINGS[MILITARY];
            IImprovement improvement = new Improvement(_maxImprovements, _basePrices, _incrementPrices, level, numberUpgrades);
            MilitaryBuilding militaryBuilding = new MilitaryBuilding(improvement, UNIT_LEVEL, _unitPowerPerLevel, name, builded);
            militaryBuilding.Image = new ImagePath(ImagePaths.MILITARY_BUILDINGS[MILITARY]);
            militaryBuilding.IconImage = new ImagePath(ImagePaths.MILITARY_BUILDINGS[MILITARY], ImagePaths.ICON_IMAGE);
            improvement.SetUpgradeDelegate(militaryBuilding.Upgrade);
            militaryBuilding.Squads = SQUADS;
            return militaryBuilding;
        }

        private void FillUnitPower(Dictionary<int, int> unitPowers)
        {
            _unitPowerPerLevel = new Dictionary<int, int>();
            foreach (var unitPower in unitPowers)
            {
                if (unitPower.Key >= MIN_LEVEL && unitPower.Key <= MAX_LEVEL)
                    _unitPowerPerLevel.Add(unitPower.Key, unitPower.Value);
            }
        }
    }
}
