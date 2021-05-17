using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles.Ai
{
    public abstract class TargetUnitMove : IUnitMove
    {
        public IBattleUnitAi Unit { get; private set; }

        protected IBattlerAi _battler;

        protected IBattleUnit _targetUnit;
        protected IBattleUnit _lastTargetUnit;
        protected int _indexAction;

        public TargetUnitMove(int indexAction, IBattleUnitAi unit, IBattlerAi battler)
        {
            _indexAction = indexAction;
            Unit = unit;
            _battler = battler;
        }

        public abstract double GetMovePrioprity();

        public void ReleaseMove(bool changed)
        {
            if (_targetUnit == null || (!changed && _battler.Battle.BattleCourse.CurrentActions.ContainsKey(Unit.BattleUnit) && _lastTargetUnit == _targetUnit))
            {
                return;
            }

            Unit.BattleUnit.Actions.GetAvailableActions()[_indexAction].Prepare(_targetUnit.BattlePoint, _battler.Battle.BattleCourse);
            _lastTargetUnit = _targetUnit;
        }
    }
}
