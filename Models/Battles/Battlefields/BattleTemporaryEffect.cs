using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Effects;

namespace NecroLib.Models.Battles.Battlefields
{
    public delegate bool RemoveTemporaryEffect(IUnitTemporaryEffect unitTemporaryEffect);

    public class BattleTemporaryEffect : IBattleTemporaryEffect
    {
        public IUnitTemporaryEffect UnitTemporaryEffect { get; private set; }
        private int _countToDone;
        private int _maxCount;

        private event RemoveTemporaryEffect _removeEffectHandler;

        public BattleTemporaryEffect(int countToDone, RemoveTemporaryEffect removeEffect, IUnitTemporaryEffect unitTemporaryEffect)
        {
            _countToDone = countToDone;
            _maxCount = countToDone;
            UnitTemporaryEffect = unitTemporaryEffect;
            _removeEffectHandler = removeEffect;
        }

        public bool? Promote()
        {
            if (_countToDone == 0)
            {
                return End();
            }
            _countToDone--;

            return null;
        }
        
        public void Refresh()
        {
            _countToDone = _maxCount;
        }

        public int GetDuration()
        {
            return _maxCount;
        }

        public int GetLeftDuration()
        {
            return _countToDone;
        }

        private bool? End()
        {
            _countToDone = _maxCount;
            return _removeEffectHandler?.Invoke(UnitTemporaryEffect);
        }

        public bool IsEqual(IBattleTemporaryEffect effect)
        {
            return UnitTemporaryEffect.IsEqual(effect.UnitTemporaryEffect);
        }
    }
}
