using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Buildings
{
    public interface IMilitaryQuarter : INameable, IIconable
    {
        Dictionary<Military, MilitaryBuildingSlot> BuildingSlots { get; }
    }
}
