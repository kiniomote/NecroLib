using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public class MainMiningBuildingBuilder : MiningBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 1; } }
        protected override int MAX_LEVEL { get { return 8; } }

        protected override Dictionary<int, int> MINING_PER_LEVEL { get { return new Dictionary<int, int>()
        {
            [1] = 15,
            [2] = 20,
            [3] = 20,
            [4] = 25,
            [5] = 30,
            [6] = 35,
            [7] = 40,
            [8] = 50,
        }; } }
        protected override Mining MINING { get { return Mining.Main; } }

        protected override int BASE_MINING { get { return 50; } }
        protected override int MINING_WORKER { get { return 5; } }
    }
}
