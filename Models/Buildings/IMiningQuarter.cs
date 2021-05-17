using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Buildings
{
    public interface IMiningQuarter : INameable, IIconable
    {
        Dictionary<Mining, MiningBuildingSlot> BuildingSlots { get; }

        void StartMining(DateTime startMining, ElapsedEventHandler saveCharacter);
        DateTime LastTimeMine { get; }
    }
}
