using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles.Pathfinder
{
    public interface IPathfinder
    {
        IBattlePoint Start { get; set; }
        IBattlePoint End { get; set; }
        IBattlefield Field { get; set; }

        List<IBattlePoint> FindPath(IBattlePoint start, IBattlePoint end, IBattlefield battlefield);
    }
}
