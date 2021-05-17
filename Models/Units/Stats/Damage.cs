using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Units.Stats
{
    public class Damage : IDamage
    {
        public DamageType DamageType { get; private set; }

        private int _minDamage;
        private int _maxDamage;

        private LocalizedString _name;

        private UnitCharacteristic _characteristic = UnitCharacteristic.Damage;

        private int _additionalMinDamage = 0;
        private int _additionalMaxDamage = 0;

        private Random _randomer = new Random();

        public Damage(int min_damage, int max_damage, DamageType damageType)
        {
            _minDamage = min_damage;
            _maxDamage = max_damage;
            _name = new LocalizedString(LocalizationNames.UNIT_CHARACTERISTICS[_characteristic]);
            DamageType = damageType;
            validate();
        }

        public int GetDamage()
        {
            return _randomer.Next(getFullMinDamage(), getFullMaxDamage() + 1);
        }

        public int GetMaxDamage()
        {
            return _maxDamage;
        }

        public int GetMinDamage()
        {
            return _minDamage;
        }

        public void ModifyMaxDamage(int value)
        {
            _additionalMaxDamage = value;
        }

        public void ModifyMinDamage(int value)
        {
            _additionalMinDamage = value;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        private void validate()
        {
            if (_minDamage < 1 || _maxDamage < 1)
            {
                throw new ArgumentException("Incorrect damage characteristic: " + _name.ToString());
            }
        }

        private int getFullMinDamage()
        {
            int fullDamage = _minDamage + _additionalMinDamage;
            return fullDamage >= 1 ? fullDamage : 1;
        }

        private int getFullMaxDamage()
        {
            int fullDamage = _maxDamage + _additionalMaxDamage;
            return fullDamage >= 1 ? fullDamage : 1;
        }

        // Static

        public static int GetRandomDamage(int minDamage, int maxDamage)
        {
            Random random = new Random();
            return random.Next(minDamage, maxDamage + 1);
        }

        public static int CalculateDamage(int damage, int attack, int armor)
        {
            double resultDamage = damage;

            if (attack > armor)
            {
                int difference = attack - armor;
                double modifier = 1 + difference * 0.01;
                resultDamage *= modifier < 4 ? modifier : 4;
            }
            else
            {
                int difference = armor - attack;
                double modifier = 1 / (1 + difference * 0.01);
                resultDamage *= modifier > 0.25 ? modifier : 0.25;
            }

            return Convert.ToInt32(Math.Round(resultDamage));
        }

    }
}
