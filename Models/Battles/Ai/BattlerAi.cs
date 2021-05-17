using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace NecroLib.Models.Battles.Ai
{
    public enum BattlerTactic
    {
        Defense,
        Attack,
    }

    public class BattlerAi : IBattlerAi
    {
        private static Dictionary<AiDifficulty, int> _difficultyTime = new Dictionary<AiDifficulty, int>()
        {
            [AiDifficulty.Easy] = 25,
            [AiDifficulty.Medium] = 18,
            [AiDifficulty.Hard] = 10,
        };

        public IBattler Battler { get; private set; }
        public IBattle Battle { get; private set; }
        public AiType AiType { get; private set; }
        public AiDifficulty AiDifficulty { get; private set; }
        public BattlerTactic Tactic { get; private set; }

        private List<IBattleUnitAi> _battleUnits;

        private int _maxCountTurn;
        private int _lastCountTurn;

        public BattlerAi(IBattler battler, IBattle battle, AiType aiType, AiDifficulty aiDifficulty)
        {
            Battler = battler;
            Battle = battle;
            AiType = aiType;
            AiDifficulty = aiDifficulty;
            Tactic = BattlerTactic.Defense;
            _battleUnits = new List<IBattleUnitAi>();
            _maxCountTurn = _difficultyTime[AiDifficulty];
            _lastCountTurn = _maxCountTurn;

            foreach (IBattleUnit unit in Battler.BattleUnits)
            {
                _battleUnits.Add(new BattleUnitAi(unit, this));
            }
        }

        public void MakeTurn()
        {
            if (_lastCountTurn > 0)
            {
                _lastCountTurn--;
                return;
            }

            _lastCountTurn = _maxCountTurn;

            CheckTactic();
            foreach (IBattleUnitAi unit in _battleUnits)
            {
                unit.MakeTurn();
            }
        }

        private void CheckTactic()
        {
            int attackerPower = 0;
            foreach (IBattleUnit unit in Battle.Attacker.GetAliveUnits())
            {
                if (unit.Actions.GetAvailableActions()[AttackMoveAi.ATTACK_ACTION].PossiblePoints(Battle.Field).Count > 0)
                {
                    attackerPower += unit.Unit.Power.GetPower() * unit.GetCount();
                }
            }

            int defenderPower = 0;
            foreach (IBattleUnit unit in Battler.GetAliveUnits())
            {
                if (unit.Actions.GetAvailableActions()[AttackMoveAi.ATTACK_ACTION].PossiblePoints(Battle.Field).Count > 0)
                {
                    defenderPower += unit.Unit.Power.GetPower() * unit.GetCount();
                }
            }

            Tactic = attackerPower > defenderPower ? BattlerTactic.Attack : BattlerTactic.Defense;
        }
    }
}
