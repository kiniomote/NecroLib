using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Ai
{
    public interface IBattleUnitAi
    {
        IBattleUnit BattleUnit { get; }
        void MakeTurn();
    }
}
