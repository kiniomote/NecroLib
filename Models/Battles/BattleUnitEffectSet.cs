using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles
{
    public class BattleUnitEffectSet : IBattleUnitEffectSet
    {
        private List<IUnitTemporaryEffect> _effects;

        public BattleUnitEffectSet()
        {
            _effects = new List<IUnitTemporaryEffect>();
        }

        public void AddEffect(IUnitTemporaryEffect effect)
        {
            if (_effects.Find(eff => eff.GetEffectType() == effect.GetEffectType()) != null)
            {
                _effects.Add(effect);
            }
        }

        public void AddEffects(List<IUnitTemporaryEffect> effects)
        {
            effects.ForEach(effect => AddEffect(effect));
        }

        public bool RemoveEffect(IUnitTemporaryEffect effect)
        {
            IUnitTemporaryEffect foundedEffect = _effects.Find(eff => eff.GetEffectType() == effect.GetEffectType());
            if (foundedEffect != null)
            {
                _effects.Remove(foundedEffect);
            }
            return foundedEffect != null;
        }

        public bool RemoveEffect(TemporaryEffect effectType)
        {
            IUnitTemporaryEffect foundedEffect = _effects.Find(eff => eff.GetEffectType() == effectType);
            if (foundedEffect != null)
            {
                _effects.Remove(foundedEffect);
            }
            return foundedEffect != null;
        }

        public List<IUnitTemporaryEffect> GetEffects()
        {
            return _effects;
        }

        public int ProccessCharacteristic(int value, UnitCharacteristic characteristic)
        {
            int changedValue = value;

            foreach(IUnitTemporaryEffect effect in _effects)
            {
                changedValue = effect.GetModifyCharacteristic(characteristic, changedValue);
            }

            return changedValue;
        }

        public int GetArmorByDamageType(int value, DamageType damageType)
        {
            int changedValue = value;

            foreach(IUnitTemporaryEffect effect in _effects)
            {
                changedValue = effect.GetArmorByDamageType(value, damageType);
            }

            return changedValue;
        }

        public bool AllowDoAction(UnitAction action)
        {
            bool allow = true;

            foreach(IUnitTemporaryEffect effect in _effects)
            {
                if (!effect.AllowDoAction(action))
                {
                    allow = false;
                    break;
                }
            }

            return allow;
        }

        public bool HasEffect(TemporaryEffect effectType)
        {
            bool hasEffect = false;

            foreach (IUnitTemporaryEffect effect in _effects)
            {
                if (effect.GetEffectType() == effectType)
                {
                    hasEffect = true;
                    break;
                }
            }

            return hasEffect;
        }
    }
}
