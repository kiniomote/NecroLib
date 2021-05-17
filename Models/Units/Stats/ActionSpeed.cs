using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Stats
{
    public class ActionSpeed : IActionSpeed
    {
        public const int BASE_SPEED = 100;

        private int _baseValue;

        private int _percentModifier = 0;

        private LocalizedString _name;

        public ActionSpeed(int base_value, UnitCharacteristic characteristic)
        {
            _baseValue = base_value;
            _name = new LocalizedString(LocalizationNames.UNIT_CHARACTERISTICS[characteristic]);
            Validate();
        }

        public void Modify(int percent)
        {
            _percentModifier += percent;
        }

        public int GetTime()
        {
            return _baseValue + _percentModifier;
        }

        public int GetModifier()
        {
            return _percentModifier;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        private void Validate()
        {
            if (_baseValue <= 0)
            {
                throw new ArgumentException("Incorrect action speed characteristic: " + _name.ToString());
            }
        }

        // Static

        public static int CalculateTimeAction(int moveSpeed)
        {
            double resultMoveSpeed = (BASE_SPEED / Convert.ToDouble(moveSpeed)) * 100;

            return Convert.ToInt32(Math.Round(resultMoveSpeed));
        }

    }
}
