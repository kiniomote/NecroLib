using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using NecroLib.Models.Items;
using NecroLib.Models.Items.ItemBuilder;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters.Items
{
    public delegate bool EnoughLevelHandler(int level);

    [Serializable]
    public class EquipmentSlot : IEquipmentSlot
    {
        [NonSerialized]
        private IItem _item;
        private ItemType _itemType;

        private LocalizedString _name;

        private string _itemName;

        public event EnoughLevelHandler EnoughLevelEvent;

        public EquipmentSlot(ItemType itemType, string localizationName)
        {
            _item = null;
            _itemType = itemType;
            _name = new LocalizedString(localizationName);
        }

        public void SetEnoughLevelEvent(EnoughLevelHandler enoughLevelHandler)
        {
            EnoughLevelEvent = enoughLevelHandler;
        }

        public bool EquipItem(IItem item)
        {
            if (!CanEquipItem(item))
                return false;
            _item = item;
            return true;
        }

        public bool CanEquipItem(IItem item)
        {
            if (EnoughLevelEvent == null)
            {
                throw new Exception("Event don't exsist in EquipmentSlot");
            }
            return _itemType == item.GetItemType() && EnoughLevelEvent(item.GetItemLevel());
        }

        public IItem UnequipItem()
        {
            IItem unequippedItem = _item;
            _item = null;
            return unequippedItem;
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            _itemName = _item?.ToString() ?? string.Empty;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            IItemBuilderGenerator generator = new ItemBuilderGenerator();
            _item = generator.Generate(_itemName);
        }

        // Getters

        public IItem GetEquippedItem()
        {
            return _item;
        }

        public ItemType GetSlotType()
        {
            return _itemType;
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
