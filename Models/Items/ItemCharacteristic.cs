using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items
{
    public class ItemCharacteristic : IItemCharacteristic
    {
        private int _value;

        private LocalizedString _name;

        public ItemCharacteristic(int value, string localizationName)
        {
            _value = value;
            _name = new LocalizedString(localizationName);
        }

        // Getters

        public string GetFullName()
        {
            return _name.ToString() + ": " + _value;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
