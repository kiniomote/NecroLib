using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles.Pathfinder
{
    public interface INode
    {
        IBattlePoint BattlePoint { get; set; }
        INode PreviousNode { get; set; }
        int Length { get; }
        int GetRow();
        int GetColumn();
    }
}
