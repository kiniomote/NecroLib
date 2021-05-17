using NecroLib.Models.Characters;
using NecroLib.Models.Resources;
using NecroLib.Models.Buildings.BuildingBuilder;
using NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public class MilitaryBuildingSlot : BuildingSlot, IMilitaryBuildingSlot
    {
        private Military _type;

        [field:NonSerialized]
        public MilitaryBuilding Building { get; private set; }

        public MilitaryBuildingSlot(Military military, int minLevel)
        {
            _type = military;
            _level = minLevel;
            _numberUpgrades = 0;
            BuildBuilding();
        }

        public void BuildOrUpgrade(IResourcePack resources, ILevel level)
        {
            if (!CanBuildOrUpgrade(resources, level))
                throw new Exception("Can't build");
            Building.Improvement.Improve(resources, level);
            _level = Building.Improvement.GetCurrentLevel();
            _numberUpgrades = Building.Improvement.GetNumberOfImprovement();
        }

        public bool CanBuildOrUpgrade(IResourcePack resources, ILevel level)
        {
            return Building.Improvement.CanImprove(resources, level);
        }

        protected override void BuildBuilding()
        {
            IBuildingBuilderGenerator generator = new BuildingBuilderGenerator();
            IMilitaryBuildingBuilder militaryBuildingBuilder = generator.GetBuilder(_type);
            Building = militaryBuildingBuilder.BuildMilitaryBuilding(_level, _numberUpgrades);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BuildBuilding();
        }

        // Getters

        public Military GetMilitaryType()
        {
            return _type;
        }

        public IPrice GetBuildOrUpgradePrice()
        {
            return Building.Improvement.GetImprovementPrice();
        }
    }
}
