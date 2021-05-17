using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters
{
    public delegate bool UpgradeHandler(int up_value);

    [Serializable]
    public class HeroCharacteristic : IHeroCharacteristic
    {
        public const int MAX_VALUE = 20;

        private int _value;
        private LocalizedString _name;
        private LocalizedString _description;

        public event UpgradeHandler UpgradeEvent;

        public HeroCharacteristic(string localizationName, UpgradeHandler upgradeHandler)
        {
            _value = 0;
            _name = new LocalizedString(localizationName, LocalizationNames.NAME);
            _description = new LocalizedString(localizationName, LocalizationNames.DESCRIPTION);
            UpgradeEvent += upgradeHandler;
        }

        public int GetValue()
        {
            return _value;
        }

        public void Upgrade(int up_value = 1)
        {
            if (_value < MAX_VALUE && UpgradeEvent != null && UpgradeEvent(up_value))
            {
                _value += up_value;
            }
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public string GetDescription()
        {
            return _description.ToString();
        }
    }
}
