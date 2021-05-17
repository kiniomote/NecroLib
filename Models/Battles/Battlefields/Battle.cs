using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Quests;
using NecroLib.Models.Characters;

namespace NecroLib.Models.Battles.Battlefields
{
    public delegate void CompleteBattle(ICharacter character, bool withoutReward = false);
    public delegate void FinishBattle(bool win);
    public delegate void BattleCoursePeriod();

    public class Battle : IBattle
    {
        public IBattler Attacker { get; private set; }
        public IBattler Defender { get; private set; }

        public IBattlefield Field { get; private set; }

        private event CompleteBattle CompleteBattleHandler;
        private event FinishBattle FinishBattleHandler;
        private ICharacter _character = null;

        public IBattleCourse BattleCourse { get; private set; }

        public Battle(IBattler attacker, IBattler defender, CompleteBattle completeBattle, ICharacter character = null)
        {
            Attacker = attacker;
            Attacker.SetBattleUnits();
            Defender = defender;
            Defender.SetBattleUnits();
            CompleteBattleHandler = completeBattle;
            _character = character;
            BattleCourse = new BattleCourse(Attacker, Defender, Finish);
        }

        public void InitBattlefield(int rows = Battlefield.ROWS, int columns = Battlefield.COLUMNS)
        {
            Field = new Battlefield(rows, columns);
            BattleCourse.SetBattlefield(Field);
        }

        public void Start()
        {
            BattleCourse.Start();
        }

        public void SetFinishActions(FinishBattle finishBattle)
        {
            FinishBattleHandler = finishBattle;
        }

        public void SetBattleCourseAction(BattleCoursePeriod battleCoursePeriod)
        {
            BattleCourse.SetBattleCourseAction(battleCoursePeriod);
        }

        public void Finish(bool win)
        {
            if (win && _character != null)
            {
                CompleteBattleHandler?.Invoke(_character, true);
            }
            FinishBattleHandler?.Invoke(win);
        }
    }
}
