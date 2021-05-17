using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;

namespace NecroLib.Models.Units.Effects
{
    public class CloackOfShadow : UnitTemporaryEffect
    {
        public const int UPGRADE_MOVE = 30;
        public const int UPGRADE_ARMOR = 30;
        public const int CHANCE_ARMOR = 30;
        public const int PERCENT = 100;

        public CloackOfShadow(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.CloackOfShadow);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch(characteristic)
            {
                case UnitCharacteristic.MovementSpeed:
                    changedValue += UPGRADE_MOVE;
                    break;
            }

            return changedValue;
        }

        public override int GetArmorByDamageType(int value, DamageType damageType)
        {
            int changedValue = value;

            Random random = new Random();
            if (random.Next(0, PERCENT) < CHANCE_ARMOR)
            {
                changedValue += UPGRADE_ARMOR;
            }

            return changedValue;
        }
    }
}
