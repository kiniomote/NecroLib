using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;

namespace NecroLib.Models.Units.Effects
{
    public class LiveShield : UnitTemporaryEffect
    {
        public const int UPGRADE = 30;

        public LiveShield(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.LiveShield);
        }

        public override int GetArmorByDamageType(int value, DamageType damageType)
        {
            int changedValue = value;

            switch (damageType)
            {
                case DamageType.Range:
                    changedValue += UPGRADE;
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
