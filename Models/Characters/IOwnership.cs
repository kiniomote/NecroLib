using NecroLib.Models.Buildings;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Characters
{
    public interface IOwnership
    {
        IResourcePack Resources { get; }
        IArmy Army { get; }
        ITown Town { get; }
    }
}
