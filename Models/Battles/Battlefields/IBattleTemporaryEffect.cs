using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Effects;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattleTemporaryEffect
    {
        IUnitTemporaryEffect UnitTemporaryEffect { get; }
        bool? Promote();

        void Refresh();

        bool IsEqual(IBattleTemporaryEffect effect);

        int GetDuration();
        int GetLeftDuration();
    }
}
