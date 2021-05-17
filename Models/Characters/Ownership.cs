using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Buildings;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;

namespace NecroLib.Models.Characters
{
    [Serializable]
    public class Ownership : IOwnership
    {
        public IResourcePack Resources { get; private set; }
        public IArmy Army { get; private set; }
        public ITown Town { get; private set; }

        public Ownership()
        {
            Resources = new ResourcePack();
            Army = new Army();
            Town = new Town(Army, Resources);
        }
    }
}
