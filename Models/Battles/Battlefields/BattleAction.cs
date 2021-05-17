using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles.Battlefields
{
    public class BattleAction : IBattleAction
    {
        public IUnitAction UnitAction { get; set; }
        private int _countToDone;
        private int _maxCount;

        public BattleAction(int countToDone, IUnitAction unitAction)
        {
            _countToDone = countToDone;
            _maxCount = countToDone;
            UnitAction = unitAction;
        }

        public bool? Promote()
        {
            if (!UnitAction.IsEnable())
                return null;
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

        private bool? Release()
        {
            bool? result = UnitAction.Realease();
            _countToDone = _maxCount;
            return !UnitAction.IsRepeat() ? result : null;
        }
    }
}
