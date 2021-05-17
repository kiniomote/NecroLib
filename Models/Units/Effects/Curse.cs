using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class Curse : UnitTemporaryEffect
    {
        public const double PERECENT = 100;
        public const int DECREASE_ATTACK = 15;
        public const double DECREASE_ATTACK_SPEED = 15;

        public Curse(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.Curse);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch (characteristic)
            {
                case UnitCharacteristic.Attack:
                    changedValue -= DECREASE_ATTACK;
                    break;
                case UnitCharacteristic.AttackSpeed:
                    double slow = (Convert.ToDouble(changedValue) / PERECENT) * DECREASE_ATTACK_SPEED;
                    changedValue -= Convert.ToInt32(slow);
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
