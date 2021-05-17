using NecroLib.Models.Items;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NecroLib.Models.Characters.Items
{
    [Serializable]
    public class EquipmentSet : IEquipmentSet
    {
        public Dictionary<SlotType, IEquipmentSlot> EquipmentSlots { get; private set; }

        private LocalizedString _name = new LocalizedString(LocalizationNames.EQUIPMENT);

        private Dictionary<SlotType, ItemType> _slotItems = new Dictionary<SlotType, ItemType>()
        {
            [SlotType.Head] = ItemType.Head,        
            [SlotType.Body] = ItemType.Body,        
            [SlotType.Weapon] = ItemType.Weapon,
            [SlotType.LeftRing] = ItemType.Ring,    
            [SlotType.RightRing] = ItemType.Ring,   
            [SlotType.Neck] = ItemType.Neck,
        };

        public EquipmentSet()
        {
            EquipmentSlots = new Dictionary<SlotType, IEquipmentSlot>();
            _slotItems.Keys.ToList().ForEach(slot => EquipmentSlots.Add(slot, new EquipmentSlot(_slotItems[slot], LocalizationNames.EQUIPMENT_SLOTS_NAMES[slot])));
        }

        public List<IEquipmentSlot> AvailableItemSlots(IItem item)
        {
            return EquipmentSlots.Values.Where(slot => slot.GetSlotType() == item.GetItemType()).ToList();
        }

        public int GetItemSetBattleCharacteristic(HeroAttribute attribute)
        {
            int attributeValue = 0;
            EquippedItems().ForEach(item => attributeValue += item.Characteristics.BattleCharacteristics[attribute].GetValue());
            return attributeValue;
        }

        public int GetItemSetMiningCharacteristic(HeroAttribute attribute)
        {
            int attributeValue = 0;
            EquippedItems().ForEach(item => attributeValue += item.Characteristics.MiningCharacteristics[attribute].GetValue());
            return attributeValue;
        }

        private List<IItem> EquippedItems()
        {
            List<IItem> items = new List<IItem>();

            foreach (IEquipmentSlot slot in EquipmentSlots.Values)
            {
                IItem item = slot.GetEquippedItem();
                if (item != null)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        // Getters

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
