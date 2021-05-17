using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public class RuneMiningBuildingBuilder : MiningBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 6; } }
        protected override int MAX_LEVEL { get { return 8; } }

        protected override Dictionary<int, int> MINING_PER_LEVEL { get { return new Dictionary<int, int>()
        {
            [6] = 20,
            [7] = 25,
            [8] = 30,
        }; } }
        protected override Mining MINING { get { return Mining.RunesWorkshop; } }

        protected override int BASE_MINING { get { return 200; } }
        protected override int MINING_WORKER { get { return 3; } }
    }
}
