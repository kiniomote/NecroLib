using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class PoisonMove : UnitTemporaryEffect
    {
        public const double PERECENT = 100;
        public const double SLOW = 20;

        public PoisonMove(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.PoisonMove);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch (characteristic)
            {
                case UnitCharacteristic.MovementSpeed:
                    double slow = (Convert.ToDouble(changedValue) / PERECENT) * SLOW;
                    changedValue -= Convert.ToInt32(slow);
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
