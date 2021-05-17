using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Battles;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;

namespace NecroLib.Models.Units.Effects
{
    public abstract class UnitTemporaryEffect : IUnitTemporaryEffect
    {
        public IBattleUnit BattleUnit { get; }
        public IImagePath IconImage { get; set; }

        protected TemporaryEffect _effectType;

        public UnitTemporaryEffect(IBattleUnit battleUnit)
        {
            BattleUnit = battleUnit;
            BattleUnit.Effects.AddEffect(this);
        }

        public virtual int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            return value;
        }

        public virtual int GetArmorByDamageType(int value, DamageType damageType)
        {
            return value;
        }

        public virtual bool IsEqual(IUnitTemporaryEffect effect)
        {
            return _effectType == effect.GetEffectType() && BattleUnit == effect.BattleUnit;
        }

        public virtual bool AllowDoAction(UnitAction action)
        {
            return true;
        }

        protected void SetEffectType(TemporaryEffect temporaryEffect)
        {
            _effectType = temporaryEffect;

            IconImage = ImagePaths.UNIT_EFFECTS.ContainsKey(_effectType) ? new ImagePath(ImagePaths.UNIT_EFFECTS[_effectType], "_icon") : null;
        }

        public TemporaryEffect GetEffectType()
        {
            return _effectType;
        }
    }
}
