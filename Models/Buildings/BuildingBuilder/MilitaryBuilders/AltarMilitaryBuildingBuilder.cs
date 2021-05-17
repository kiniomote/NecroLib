using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;

namespace NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders
{
    public class AltarMilitaryBuildingBuilder : MilitaryBuildingBuilder
    {
        protected override int MIN_LEVEL { get { return 2; } }
        protected override int MAX_LEVEL { get { return 5; } }

        protected override List<SquadType> SQUADS { get { return new List<SquadType>() {SquadType.Magic }; } }

        protected override Military MILITARY { get { return Military.AltarOfMagic; } }

        protected override UnitLevel UNIT_LEVEL { get { return UnitLevel.Common; } }
    }
}
