using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Characters;

namespace NecroLib.Models.Battles
{
    public interface IBattler
    {
        Dictionary<HeroAttribute, int> BattleAttributes { get; }
        List<IBattleSquad> BattleSquads { get; }
        List<IBattleUnit> BattleUnits { get; }
        IBattlefieldPosition BattlefieldPosition { get; }

        List<IBattleUnit> GetAliveUnits();
        void SetBattleUnits();
        bool IsAliveUnits();
    }
}
