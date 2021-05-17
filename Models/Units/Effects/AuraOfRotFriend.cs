using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class AuraOfRotFriend : UnitTemporaryEffect
    {
        public const int INCREASE_ATTACK = 10;
        public const int INCREASE_ARMOR = 10;

        public AuraOfRotFriend(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.AuraOfRotFriend);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch (characteristic)
            {
                case UnitCharacteristic.Attack:
                    changedValue += INCREASE_ATTACK;
                    break;
                case UnitCharacteristic.Armor:
                    changedValue += INCREASE_ARMOR;
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
