using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Battlefields
{
    public interface IBattle
    {
        IBattler Attacker { get; }
        IBattler Defender { get; }
        IBattlefield Field { get; }
        IBattleCourse BattleCourse { get; }

        void Start();
        void InitBattlefield(int rows = Battlefield.ROWS, int columns = Battlefield.COLUMNS);
        void Finish(bool win);
        void SetFinishActions(FinishBattle finishBattle);
        void SetBattleCourseAction(BattleCoursePeriod battleCoursePeriod);
    }
}
