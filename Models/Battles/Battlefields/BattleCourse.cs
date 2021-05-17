using NecroLib.Models.Battles.Ai;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace NecroLib.Models.Battles.Battlefields
{
    public class BattleCourse : IBattleCourse
    {
        public const int DEFAULT_DELAY = 10;
        public const int DEFAULT_SPEED = 2;
        public const int MIN_SPEED = 2;
        public const int MAX_SPEED = 8;

        private Timer _timer;

        private IBattler _attacker;
        private IBattler _defender;
        private IBattlefield _field;
        private event FinishBattle _finishBattleHandler;
        private event BattleCoursePeriod _battleCoursePeriodHandler;

        public Dictionary<IBattleUnit, IBattleAction> CurrentActions { get; private set; }
        public List<IBattleExecuteAction> CurrentExecuteActions { get; private set; }
        public List<IBattleTemporaryEffect> TemporaryEffects { get; private set; }

        private List<IBattleUnit> _actionsOnDelete;
        private List<IBattleTemporaryEffect> _effectsOnDelete;
        private List<IBattleExecuteAction> _executeActionsOnDelete;

        private IBattlerAi _defenderBattlerAi;

        private int _currentSpeed = DEFAULT_SPEED;

        public BattleCourse(IBattler attacker, IBattler defender, FinishBattle finishBattle)
        {
            _attacker = attacker;
            _defender = defender;
            _finishBattleHandler = finishBattle;
            CurrentActions = new Dictionary<IBattleUnit, IBattleAction>();
            TemporaryEffects = new List<IBattleTemporaryEffect>();
            CurrentExecuteActions = new List<IBattleExecuteAction>();
            _actionsOnDelete = new List<IBattleUnit>();
            _effectsOnDelete = new List<IBattleTemporaryEffect>();
            _executeActionsOnDelete = new List<IBattleExecuteAction>();
            _timer = new Timer(GetDelay());
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;
        }

        public void Start()
        {
            CurrentActions = new Dictionary<IBattleUnit, IBattleAction>();
            TemporaryEffects = new List<IBattleTemporaryEffect>();
            CurrentExecuteActions = new List<IBattleExecuteAction>();
            _actionsOnDelete = new List<IBattleUnit>();
            _effectsOnDelete = new List<IBattleTemporaryEffect>();
            _executeActionsOnDelete = new List<IBattleExecuteAction>();
            _timer.Start();
        }

        public void SetBattleCourseAction(BattleCoursePeriod battleCoursePeriod)
        {
            _battleCoursePeriodHandler = battleCoursePeriod;
        }

        public void SetDefenderAi(IBattle battle, AiType aiType, AiDifficulty aiDifficulty)
        {
            _defenderBattlerAi = new BattlerAi(_defender, battle, aiType, aiDifficulty);
        }

        public int GetCurrentSpeed()
        {
            return _currentSpeed;
        }

        public bool StopResumeBattle()
        {
            _timer.Enabled = !_timer.Enabled;
            return _timer.Enabled;
        }

        public void DecreaseDelay()
        {
            if (_currentSpeed <= MIN_SPEED)
                return;
            _currentSpeed /= 2;
            _timer.Interval = GetDelay();
        }

        public void IncreaseDelay()
        {
            if (_currentSpeed >= MAX_SPEED)
                return;
            _currentSpeed *= 2;
            _timer.Interval = GetDelay();
        }

        public void AddBattleEvent(IBattleUnit unit, IBattleAction action)
        {
            if (CurrentActions.ContainsKey(unit))
                CurrentActions[unit] = action;
            else
                CurrentActions.Add(unit, action);
        }

        public void PrepareBattleEventToDelete(IBattleUnit unit)
        {
            if (!_actionsOnDelete.Contains(unit))
            {
                _actionsOnDelete.Add(unit);
            }
        }

        public void RemoveBattleEvent(IBattleUnit unit)
        {
            CurrentActions.Remove(unit);
        }

        public void AddTemporaryEffect(IBattleTemporaryEffect battleTemporaryEffect)
        {
            IBattleTemporaryEffect effect = TemporaryEffects.Find(ef => ef.IsEqual(battleTemporaryEffect));
            if (effect != null)
                effect.Refresh();
            else
                TemporaryEffects.Add(battleTemporaryEffect);
        }

        public void SetBattlefield(IBattlefield battlefield)
        {
            _field = battlefield;
        }

        public IBattlefield GetBattlefield()
        {
            return _field;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            bool? end = CheckEndBattle();
            if (end != null)
            {
                _timer.Stop();
                _finishBattleHandler?.Invoke(end == true);
                return;
            }

            ProccessActions();
            ProccessEffects();
            ProccessExecuteActions();
            _defenderBattlerAi?.MakeTurn();
            _battleCoursePeriodHandler?.Invoke();
        }

        private void ProccessActions()
        {
            foreach (var action in CurrentActions)
            {
                bool? actionDone = action.Value.Promote();
                if (actionDone != null)
                    PrepareBattleEventToDelete(action.Key);
            }

            foreach (IBattleUnit unit in _actionsOnDelete)
            {
                RemoveBattleEvent(unit);
            }
            _actionsOnDelete.Clear();
        }

        private void ProccessEffects()
        {
            foreach (IBattleTemporaryEffect effect in TemporaryEffects)
            {
                bool? effectEnd = effect.Promote();
                if (effectEnd != null && !_effectsOnDelete.Contains(effect))
                    _effectsOnDelete.Add(effect);
            }

            foreach (IBattleTemporaryEffect effect in _effectsOnDelete)
            {
                TemporaryEffects.Remove(effect);
            }
            _effectsOnDelete.Clear();
        }

        private void ProccessExecuteActions()
        {
            foreach (IBattleExecuteAction executeAction in CurrentExecuteActions)
            {
                bool? executed = executeAction.Promote();
                if (executed != null)
                    _executeActionsOnDelete.Add(executeAction);
            }

            foreach (IBattleExecuteAction executeAction in _executeActionsOnDelete)
            {
                CurrentExecuteActions.Remove(executeAction);
            }
            _executeActionsOnDelete.Clear();
        }

        private bool? CheckEndBattle()
        {
            if (!_defender.IsAliveUnits())
                return true;
            if (!_attacker.IsAliveUnits())
                return false;
            return null;
        }

        private int GetDelay()
        {
            return DEFAULT_DELAY * _currentSpeed;
        }
    }
}
