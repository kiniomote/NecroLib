using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class AuraOfRotEnemy : UnitTemporaryEffect
    {
        public const int DECREASE_ATTACK = -10;
        public const int DECREASE_ARMOR = -10;

        public AuraOfRotEnemy(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.AuraOfRotEnemy);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch (characteristic)
            {
                case UnitCharacteristic.Attack:
                    changedValue += DECREASE_ATTACK;
                    break;
                case UnitCharacteristic.Armor:
                    changedValue += DECREASE_ARMOR;
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
