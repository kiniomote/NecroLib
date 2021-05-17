using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;

namespace NecroLib.Models.Units.Effects
{
    public class MagicArmor : UnitTemporaryEffect
    {
        public const int UPGRADE = 30;

        public MagicArmor(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.MagicArmor);
        }

        public override int GetArmorByDamageType(int value, DamageType damageType)
        {
            int changedValue = value;

            switch (damageType)
            {
                case DamageType.Magic:
                    changedValue += UPGRADE;
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
