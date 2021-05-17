using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles.Ai
{
    public enum AiType
    {
        Balanced,
        Crazy,
        Tactical,
        Restrained,
        Coward,
    }

    public enum AiDifficulty
    {
        Easy,
        Medium,
        Hard,
    }

    public interface IBattlerAi
    {
        IBattler Battler { get; }
        IBattle Battle { get; }

        AiType AiType { get; }
        AiDifficulty AiDifficulty { get; }
        BattlerTactic Tactic { get; }

        void MakeTurn();
    }
}
