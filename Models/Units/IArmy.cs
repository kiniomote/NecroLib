using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units
{
    public interface IArmy : INameable
    {
        Dictionary<SquadType, ISquad> Squads { get; }

        Dictionary<SquadType, ISquad> GetSquadsWithUnits();
        Dictionary<SquadType, ISquad> GetAvailableSquads();
    }
}
