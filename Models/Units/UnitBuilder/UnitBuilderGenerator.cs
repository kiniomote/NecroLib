using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.UnitBuilder
{
    public class UnitBuilderGenerator : IUnitBuilderGenerator
    {
        private static readonly Dictionary<SquadType, IUnitBuilder> BUILDERS = new Dictionary<SquadType, IUnitBuilder>()
        {
            [SquadType.Archer] = new ArcherBuilder(),
            [SquadType.LightInfantry] = new LightInfantryBuilder(),
            [SquadType.HeavyInfantry] = new HeavyInfantryBuilder(),
            [SquadType.Cavalry] = new CavalryBuilder(),
            [SquadType.SpecialForce] = new SpecialForceBuilder(),
            [SquadType.Thrower] = new ThrowerBuilder(),
            [SquadType.UltimateForce] = new UltimateForceBuilder(),
            [SquadType.Magic] = new MagicBuilder(),
            [SquadType.Support] = new SupportBuilder(),
        };

        public IUnitBuilder GetBuilder(SquadType squadType)
        {
            return BUILDERS[squadType];
        }
    }
}
