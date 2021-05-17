using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders
{
    public interface IMiningBuildingBuilder
    {
        MiningBuilding BuildMiningBuilding(int level, int numberUpgrades);
    }
}
