using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public class StoneMiningBuildingBuilder : MiningBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 1; } }
        protected override int MAX_LEVEL { get { return 8; } }

        protected override Dictionary<int, int> MINING_PER_LEVEL { get { return new Dictionary<int, int>()
        {
            [1] = 25,
            [2] = 30,
            [3] = 40,
            [4] = 50,
            [5] = 60,
            [6] = 75,
            [7] = 90,
            [8] = 100,
        }; } }
        protected override Mining MINING { get { return Mining.StoneQuarry; } }

        protected override int BASE_MINING { get { return 100; } }
        protected override int MINING_WORKER { get { return 25; } }
    }
}
