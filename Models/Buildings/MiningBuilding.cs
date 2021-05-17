using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public enum Mining
    {
        Main=0,
        StoneQuarry=1,
        CursedIronMine=2,
        RottenSilkFactory=3,
        RunesWorkshop=4,
    }

    public class MiningBuilding : Building
    {
        public IMiner Miner { get; private set; }

        public Mining Mining { get; }

        public static Dictionary<Mining, ResourceType> MiningResources = new Dictionary<Mining, ResourceType>()
        {
            [Mining.Main] = ResourceType.Rot,
            [Mining.StoneQuarry] = ResourceType.Stone,
            [Mining.CursedIronMine] = ResourceType.Metal,
            [Mining.RottenSilkFactory] = ResourceType.Silk,
            [Mining.RunesWorkshop] = ResourceType.Rune,
        };

        private Dictionary<int, int> _miningPerLevel;

        public MiningBuilding(Mining mining, IImprovement improvement, Dictionary<int, int> miningPerLevel, IMiner miner, string name, bool builded = false) 
            : base(improvement, name, builded)
        {
            _miningPerLevel = miningPerLevel;
            Miner = miner;
            Mining = mining;
        }

        public override void Upgrade(int level, int numberImprovement)
        {
            if (!_builded) 
                _builded = true;
            Miner.ImprovementMining = Improvement.GetValueOfUpgrade(level, numberImprovement, _miningPerLevel);
        }

        public int GetMining()
        {
            return _builded ? Miner.GetFullMining() : 0;
        }

        public int GetNextMining()
        {
            int nextLevel = Improvement.GetNextImprovementLevel();
            int numberUpgrade = Improvement.GetNumberOfImprovement();
            return (Miner.BaseMining + Improvement.GetValueOfUpgrade(nextLevel, nextLevel == Improvement.GetCurrentLevel() ? numberUpgrade + 1 : numberUpgrade, _miningPerLevel)) * Miner.MiningPerWorker;
        }
    }
}
