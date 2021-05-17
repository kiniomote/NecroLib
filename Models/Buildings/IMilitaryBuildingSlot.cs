using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public interface IMilitaryBuildingSlot : IBuildingSlot
    {
        MilitaryBuilding Building { get; }

        Military GetMilitaryType();
    }
}
