using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles.Ai
{
    public abstract class TargetPointUnitMove : IUnitMove
    {
        public const int MOVE_ACTION = 1;

        public IBattleUnitAi Unit { get; private set; }

        protected IBattlerAi _battler;

        protected IBattlePoint _targetBattlePoint;
        protected IBattlePoint _lastTargetBattlePoint;

        public TargetPointUnitMove(IBattleUnitAi unit, IBattlerAi battler)
        {
            Unit = unit;
            _battler = battler;
        }

        public abstract double GetMovePrioprity();

        public void ReleaseMove(bool changed)
        {
            if (_targetBattlePoint == null || (!changed && _battler.Battle.BattleCourse.CurrentActions.ContainsKey(Unit.BattleUnit) && _lastTargetBattlePoint == _targetBattlePoint))
            {
                return;
            }

            Unit.BattleUnit.Actions.GetAvailableActions()[MOVE_ACTION].Prepare(_targetBattlePoint, _battler.Battle.BattleCourse);
            _lastTargetBattlePoint = _targetBattlePoint;
        }
    }
}
