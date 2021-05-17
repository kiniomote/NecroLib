using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public class ExperimentalMilitaryBuildingBuilder : MilitaryBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 5; } }
        protected override int MAX_LEVEL { get { return 8; } }

        protected override List<SquadType> SQUADS { get { return new List<SquadType>() { SquadType.SpecialForce }; } }

        protected override Military MILITARY { get { return  Military.ExperimentalLab; } }

        protected override UnitLevel UNIT_LEVEL { get { return  UnitLevel.Common; } }
    }
}
