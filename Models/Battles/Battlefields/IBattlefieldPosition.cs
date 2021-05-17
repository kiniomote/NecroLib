using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattlefieldPosition
    {
        List<IBattlePoint> SquadPositions { get; }
        int GetRows();
        int GetColumns();
    }
}
