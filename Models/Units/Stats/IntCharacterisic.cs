using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Stats
{
    public class IntCharacterisic : ICharacteristic<int>
    {
        private int _baseValue;
        private LocalizedString _name;

        private int _additionalValue = 0;
        private int _minValue;

        public IntCharacterisic(int base_value, UnitCharacteristic characteristic, int minValue = 1)
        {
            _baseValue = base_value;
            _name = new LocalizedString(LocalizationNames.UNIT_CHARACTERISTICS[characteristic]);
            _minValue = minValue;
            Validate();
        }

        public int GetValue()
        {
            return getFullCharacteristic();
        }

        public void Modify(int additional_value)
        {
            _additionalValue += additional_value;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        private int getFullCharacteristic()
        {
            int full_characteristic = _baseValue + _additionalValue;
            return full_characteristic >= 1 ? full_characteristic : 1;
        }

        private void Validate()
        {
            if (_baseValue < _minValue)
            {
                throw new ArgumentException("Incorrect value characteristic: " + _name.ToString());
            }
        }
    }
}
