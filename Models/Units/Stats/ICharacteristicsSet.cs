using NecroLib.Models.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Stats
{
    public enum UnitCharacteristic
    {
        Health=0,
        Attack=1,
        Armor=2,
        RangeAttack=3,
        FlightSpeed=4,
        MovementSpeed=5,
        AttackSpeed=6,
        Damage=7,
        MinDamage=8,
        MaxDamage=9,
    }

    public interface ICharacteristicsSet : IDictIconable<UnitCharacteristic>
    {
        ICharacteristic<int> Health { get; }
        ICharacteristic<int> Attack { get; }
        ICharacteristic<int> Armor { get; }
        ICharacteristic<int> RangeAttack { get; }
        ICharacteristic<int> FlightSpeed { get; }
        IActionSpeed MovementSpeed { get; }
        IActionSpeed AttackSpeed { get; }
        IDamage Damage { get; }

        int GetCharacteristicValue(UnitCharacteristic characteristic);
    }
}
