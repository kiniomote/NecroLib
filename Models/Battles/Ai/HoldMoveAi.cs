using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles.Ai
{
    public class HoldMoveAi : IUnitMove
    {
        public IBattleUnitAi Unit { get; private set; }

        private IBattlerAi _battler;

        private IUnitAction _unitAction;

        public HoldMoveAi(IBattleUnitAi unit, IBattlerAi battler)
        {
            Unit = unit;
            _battler = battler;
            _unitAction = Unit.BattleUnit.Actions.GetAvailableActions()[AttackMoveAi.ATTACK_ACTION];
        }

        public double GetMovePrioprity()
        {
            double priority = 0;

            if (_battler.Tactic == BattlerTactic.Attack)
            {
                return priority;
            }

            List<IBattlePoint> enemies = _unitAction.PossiblePoints(_battler.Battle.Field);
            if (enemies.Count > 0)
            {
                return priority;
            }

            priority = 10;

            return priority;
        }

        public void ReleaseMove(bool changed)
        {
            if (!changed || !_battler.Battle.BattleCourse.CurrentActions.ContainsKey(Unit.BattleUnit))
            {
                return;
            }

            _battler.Battle.BattleCourse.RemoveBattleEvent(Unit.BattleUnit);
        }
    }
}
