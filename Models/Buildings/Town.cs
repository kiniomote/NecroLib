using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public class Town : ITown
    {
        public IMilitaryQuarter MilitaryQuarter { get; private set; }
        public IMiningQuarter MiningQuarter { get; private set; }

        public Town(IArmy army, IResourcePack resourcePack)
        {
            MiningQuarter = new MiningQuarter(resourcePack);
            MilitaryQuarter = new MilitaryQuarter(army);
        }
    }
}
