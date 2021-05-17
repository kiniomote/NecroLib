using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;

namespace NecroLib.Models.Units.Effects
{
    public class CoverOfDarkness : UnitTemporaryEffect
    {
        public const int UPGRADE = 50;

        public CoverOfDarkness(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.CoverOfDarkness);
        }

        public override int GetArmorByDamageType(int value, DamageType damageType)
        {
            int changedValue = value;

            switch (damageType)
            {
                case DamageType.Range:
                    changedValue += UPGRADE;
                    break;
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
