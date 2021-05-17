using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public class CemetryMilitaryBuildingBuilder : MilitaryBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 1; } }
        protected override int MAX_LEVEL { get { return 3; } }

        protected override List<SquadType> SQUADS { get { return new List<SquadType>() { SquadType.LightInfantry, SquadType.Archer }; } }

        protected override Military MILITARY { get { return Military.Cemetry; } }

        protected override UnitLevel UNIT_LEVEL { get { return UnitLevel.Common; } }
    }
}
