using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using NecroLib.Models.Units.Require;
using System.Text;

namespace NecroLib.Models.Units
{
    [Serializable]
    public class Army : IArmy
    {
        private LocalizedString _name = new LocalizedString(LocalizationNames.ARMY);

        public Dictionary<SquadType, ISquad> Squads { get; private set; }

        public Army()
        {
            Squads = new Dictionary<SquadType, ISquad>();
            UnitPower.InitSquadsUnitPower.Keys.ToList().ForEach(type => Squads.Add(type, new Squad(type, UnitPower.InitSquadsUnitPower[type])));
        }

        public Dictionary<SquadType, ISquad> GetSquadsWithUnits()
        {
            Dictionary<SquadType, ISquad> squads = new Dictionary<SquadType, ISquad>();
            foreach (var squad in Squads)
            {
                if (squad.Value.GetCountUnits() > 0)
                    squads.Add(squad.Key, squad.Value);
            }
            return squads;
        }

        public Dictionary<SquadType, ISquad> GetAvailableSquads()
        {
            Dictionary<SquadType, ISquad> squads = new Dictionary<SquadType, ISquad>();
            foreach (var squad in Squads)
            {
                if (squad.Value.GetSizeSquad() > 0)
                    squads.Add(squad.Key, squad.Value);
            }
            return squads;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            Squads.OnDeserialization(context);
        }
    }
}
