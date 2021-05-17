using NecroLib.Models.Buildings.BuildingBuilder;
using NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders;
using NecroLib.Models.Characters;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public class MiningBuildingSlot : BuildingSlot, IMiningBuildingSlot
    {
        private Mining _type;

        [field: NonSerialized]
        public MiningBuilding Building { get; private set; }

        public MiningBuildingSlot(Mining mining, int minLevel)
        {
            _type = mining;
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
            IMiningBuildingBuilder miningBuildingBuilder = generator.GetBuilder(_type);
            Building = miningBuildingBuilder.BuildMiningBuilding(_level, _numberUpgrades);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BuildBuilding();
        }

        // Getters

        public Mining GetMiningType()
        {
            return _type;
        }

        public IPrice GetBuildOrUpgradePrice()
        {
            return Building.Improvement.GetImprovementPrice();
        }
    }
}
