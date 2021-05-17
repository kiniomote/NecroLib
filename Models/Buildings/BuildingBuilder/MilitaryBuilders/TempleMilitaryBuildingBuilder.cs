using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public class TempleMilitaryBuildingBuilder : MilitaryBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 5; } }
        protected override int MAX_LEVEL { get { return 7; } }

        protected override List<SquadType> SQUADS { get { return new List<SquadType>() { SquadType.Support }; } }

        protected override Military MILITARY { get { return Military.TempleOfDeath; } }

        protected override UnitLevel UNIT_LEVEL { get { return UnitLevel.Common; } }
    }
}
