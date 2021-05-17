using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders;
using NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders;

namespace NecroLib.Models.Buildings.BuildingBuilder
{
    public interface IBuildingBuilderGenerator
    {
        IMiningBuildingBuilder GetBuilder(Mining mining);
        IMilitaryBuildingBuilder GetBuilder(Military military);
    }
}
