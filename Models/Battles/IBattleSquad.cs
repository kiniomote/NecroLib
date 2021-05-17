using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;
using NecroLib.Models.Images;

namespace NecroLib.Models.Battles
{
    public interface IBattleSquad : IImageable
    {
        UnitLevel UnitLevel { get; }

        IUnit BuildUnit();

        SquadType GetSquadType();
        int GetCountUnits();
        int GetSizeSquad();
    }
}
