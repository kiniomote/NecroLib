using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;

namespace NecroLib.Models.Units.Effects
{
    public class Charger : UnitTemporaryEffect
    {
        public const int INCREASE_ATTACK = 50;

        public Charger(IBattleUnit battleUnit) : base(battleUnit)
        {
            SetEffectType(TemporaryEffect.ChargerMove);
        }

        public override int GetModifyCharacteristic(UnitCharacteristic characteristic, int value)
        {
            int changedValue = value;

            switch (characteristic)
            {
                case UnitCharacteristic.Attack:
                    changedValue += INCREASE_ATTACK;
                    break;
                default:
                    break;
            }

            return changedValue;
        }
    }
}
