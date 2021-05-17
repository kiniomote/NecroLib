using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Ai;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattleCourse
    {
        void Start();
        void IncreaseDelay();
        void DecreaseDelay();
        bool StopResumeBattle();

        void SetBattlefield(IBattlefield battlefield);
        IBattlefield GetBattlefield();
        Dictionary<IBattleUnit, IBattleAction> CurrentActions { get; }
        List<IBattleExecuteAction> CurrentExecuteActions { get; }
        List<IBattleTemporaryEffect> TemporaryEffects { get; }

        int GetCurrentSpeed();
        void AddBattleEvent(IBattleUnit unit, IBattleAction action);
        void PrepareBattleEventToDelete(IBattleUnit unit);
        void AddTemporaryEffect(IBattleTemporaryEffect battleTemporaryEffect);
        void RemoveBattleEvent(IBattleUnit unit);
        void SetBattleCourseAction(BattleCoursePeriod battleCoursePeriod);
        void SetDefenderAi(IBattle battle, AiType aiType, AiDifficulty aiDifficulty);
    }
}
