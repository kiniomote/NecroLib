using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public interface IMiningBuildingSlot : IBuildingSlot
    {
        MiningBuilding Building { get; }

        Mining GetMiningType();
    }
}
