using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroLib.Models.Items
{
    public class Item : IItem
    {
        private int _itemLevel;
        private ItemType _itemType;

        public IItemCharacteristicSet Characteristics { get; private set; }

        private LocalizedString _name;
        private LocalizedString _description;

        public IImagePath Image { get; set; }

        public Item(int level, ItemType itemType, IItemCharacteristicSet characteristics, string name)
        {
            _itemLevel = level;
            _itemType = itemType;
            Characteristics = characteristics;
            _name = new LocalizedString(name, LocalizationNames.NAME);
            _description = new LocalizedString(name, LocalizationNames.DESCRIPTION);
        }

        // Getters

        public int GetItemLevel()
        {
            return _itemLevel;
        }

        public ItemType GetItemType()
        {
            return _itemType;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public string GetDescription()
        {
            return _description.ToString();
        }

        public override string ToString()
        {
            return _name.GetName();
        }
    }
}
