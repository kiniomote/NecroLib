using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Stats
{
    public class CharacteristicsSet : ICharacteristicsSet
    {
        public ICharacteristic<int> Health { get; private set; }
        public ICharacteristic<int> Attack { get; private set; }
        public ICharacteristic<int> Armor { get; private set; }
        public ICharacteristic<int> RangeAttack { get; private set; }
        public ICharacteristic<int> FlightSpeed { get; private set; }
        public IActionSpeed MovementSpeed { get; private set; }
        public IActionSpeed AttackSpeed { get; private set; }
        public IDamage Damage { get; private set; }

        public Dictionary<UnitCharacteristic, IImagePath> IconImages { get; }

        public CharacteristicsSet(Dictionary<UnitCharacteristic, int> characteristics, DamageType damageType)
        {
            List<UnitCharacteristic> unitCharacteristics = new List<UnitCharacteristic>() 
            { 
                UnitCharacteristic.Health, 
                UnitCharacteristic.Armor,
                UnitCharacteristic.Attack,
                UnitCharacteristic.RangeAttack,
                UnitCharacteristic.FlightSpeed,
                UnitCharacteristic.MovementSpeed,
                UnitCharacteristic.AttackSpeed,
                UnitCharacteristic.Damage
            };

            Health = new IntCharacterisic(characteristics[UnitCharacteristic.Health], UnitCharacteristic.Health);
            Attack = new IntCharacterisic(characteristics[UnitCharacteristic.Attack], UnitCharacteristic.Attack);
            Armor = new IntCharacterisic(characteristics[UnitCharacteristic.Armor], UnitCharacteristic.Armor);
            RangeAttack = new IntCharacterisic(characteristics[UnitCharacteristic.RangeAttack], UnitCharacteristic.RangeAttack);
            FlightSpeed = new IntCharacterisic(characteristics[UnitCharacteristic.FlightSpeed], UnitCharacteristic.FlightSpeed, 0);

            MovementSpeed = new ActionSpeed(characteristics[UnitCharacteristic.MovementSpeed], UnitCharacteristic.MovementSpeed);
            AttackSpeed = new ActionSpeed(characteristics[UnitCharacteristic.AttackSpeed], UnitCharacteristic.AttackSpeed);

            Damage = new Damage(characteristics[UnitCharacteristic.MinDamage], characteristics[UnitCharacteristic.MaxDamage], damageType);

            IconImages = new Dictionary<UnitCharacteristic, IImagePath>();

            foreach (UnitCharacteristic stat in unitCharacteristics)
            {
                IconImages.Add(stat, new ImagePath(ImagePaths.UNIT_CHARACTERISTICS[stat], ImagePaths.ICON_IMAGE));
            }
        }

        public int GetCharacteristicValue(UnitCharacteristic characteristic)
        {
            int value;

            switch (characteristic)
            {
                case UnitCharacteristic.Attack:
                    value = Attack.GetValue();
                    break;
                case UnitCharacteristic.Armor:
                    value = Armor.GetValue();
                    break;
                case UnitCharacteristic.AttackSpeed:
                    value = AttackSpeed.GetTime();
                    break;
                case UnitCharacteristic.MovementSpeed:
                    value = MovementSpeed.GetTime();
                    break;
                case UnitCharacteristic.Health:
                    value = Health.GetValue();
                    break;
                case UnitCharacteristic.Damage:
                    value = Damage.GetDamage();
                    break;
                case UnitCharacteristic.RangeAttack:
                    value = RangeAttack.GetValue();
                    break;
                case UnitCharacteristic.FlightSpeed:
                    value = FlightSpeed.GetValue();
                    break;
                case UnitCharacteristic.MinDamage:
                    value = Damage.GetMinDamage();
                    break;
                case UnitCharacteristic.MaxDamage:
                    value = Damage.GetMaxDamage();
                    break;
                default:
                    throw new Exception("Unknown characteristic: " + characteristic);
            }

            return value;
        }
    }
}
