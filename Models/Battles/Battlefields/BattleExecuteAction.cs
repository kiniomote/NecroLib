using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles.Battlefields
{
    public class BattleExecuteAction : IBattleExecuteAction
    {
        public IUnitExecuteAction UnitExecuteAction { get; set; }
        private int _countToDone;
        private int _maxCount;

        public BattleExecuteAction(int countToDone, IUnitExecuteAction unitExecuteAction)
        {
            _countToDone = countToDone;
            _maxCount = countToDone;
            UnitExecuteAction = unitExecuteAction;
        }

        public bool? Promote()
        {
            if (_countToDone == 0)
            {
                return Release();
            }
            _countToDone--;

            return null;
        }

        public int GetDuration()
        {
            return _maxCount;
        }

        public int GetLeftDuration()
        {
            return _countToDone;
        }

        private bool Release()
        {
            bool result = UnitExecuteAction.Release();
            _countToDone = _maxCount;
            return result;
        }
    }
}
