using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Units.Require;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units
{
    public enum UnitLevel
    {
        Common=0,
        FirstUpgraded=1,
    }

    public interface IUnit : INameable, IDescribeable, IIconable
    {
        IUnitPower Power { get; }
        ICharacteristicsSet Characteristics { get; }
        IWorth Worth { get; }
        IUnitAbilitySet Abilities { get; }
        SquadType SquadType { get; }
    }
}
