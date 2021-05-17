using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public abstract class MiningBuildingBuilder : BuildingBuilder, IMiningBuildingBuilder
    {
        protected virtual Dictionary<int, int> MINING_PER_LEVEL { get; }

        protected virtual Mining MINING { get; }

        protected virtual int BASE_MINING { get; }
        protected virtual int MINING_WORKER { get; }
        public static int DELAY { get { return 60; } }

        protected MiningBuildingBuilder()
        {
            FillData(DEFAULT_MAX_IMPROVEMENTS, DEFAULT_MINING_BASE_PRICES, DEFAULT_MINING_INCREMENT_PRICES);
        }

        public MiningBuilding BuildMiningBuilding(int level, int numberUpgrades)
        {
            bool builded = numberUpgrades != 0;
            string name = LocalizationNames.MINING_BUILDINGS[MINING];
            IImprovement improvement = new Improvement(_maxImprovements, _basePrices, _incrementPrices, level, numberUpgrades);
            IMiner miner = new Miner(BASE_MINING, MINING_WORKER, DELAY);
            MiningBuilding miningBuilding = new MiningBuilding(MINING, improvement, MINING_PER_LEVEL, miner, name, builded);
            miningBuilding.Image = new ImagePath(ImagePaths.MINING_BUILDINGS[MINING]);
            miningBuilding.IconImage = new ImagePath(ImagePaths.MINING_BUILDINGS[MINING], ImagePaths.ICON_IMAGE);
            improvement.SetUpgradeDelegate(miningBuilding.Upgrade);
            if (numberUpgrades != 0)
            {
                miningBuilding.Upgrade(level, numberUpgrades);
            }
            return miningBuilding;
        }
    }
}
