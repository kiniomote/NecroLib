using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public interface IMilitaryBuildingBuilder
    {
        MilitaryBuilding BuildMilitaryBuilding(int level, int numberUpgrades);
    }
}
