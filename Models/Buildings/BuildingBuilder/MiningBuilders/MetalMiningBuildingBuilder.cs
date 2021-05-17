using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public class MetalMiningBuildingBuilder : MiningBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 1; } }
        protected override int MAX_LEVEL { get { return 8; } }

        protected override Dictionary<int, int> MINING_PER_LEVEL { get { return new Dictionary<int, int>()
        {
            [1] = 20,
            [2] = 25,
            [3] = 35,
            [4] = 40,
            [5] = 45,
            [6] = 50,
            [7] = 55,
            [8] = 60,
        }; } }
        protected override Mining MINING { get { return Mining.CursedIronMine; } }

        protected override int BASE_MINING { get { return 100; } }
        protected override int MINING_WORKER { get { return 15; } }
    }
}
