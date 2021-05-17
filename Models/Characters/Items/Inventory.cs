using NecroLib.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using NecroLib.Models.Items.ItemBuilder;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters.Items
{
    [Serializable]
    public class Inventory : IInventory
    {
        public const int NO_LEVEL_FILTER = -1;

        public IEquipmentSet Equipments { get; private set; }

        [field: NonSerialized]
        public List<IItem> Items { get; private set; }
        private List<string> _items;

        [field: NonSerialized]
        public List<IBlueprint> Blueprints { get; private set; }
        private List<string> _blueprints;

        private LocalizedString _name = new LocalizedString(LocalizationNames.INVENTORY);

        public Inventory()
        {
            Items = new List<IItem>();
            Equipments = new EquipmentSet();
            Blueprints = new List<IBlueprint>();
        }

        public List<IItem> GetItemsByFilter(ItemType itemType = ItemType.All, int level = NO_LEVEL_FILTER)
        {
            List<IItem> filteredItems = Items;

            if (level != NO_LEVEL_FILTER)
                filteredItems = filteredItems.Where(item => item.GetItemLevel() == level).ToList();
            if (itemType != ItemType.All)
                filteredItems = filteredItems.Where(item => item.GetItemType() == itemType).ToList();

            return filteredItems;
        }

        public bool EquipItem(IItem item, IEquipmentSlot slot)
        {
            if (!slot.CanEquipItem(item))
                return false;

            if (slot.GetEquippedItem() != null)
            {
                UnequipItem(slot);
            }

            bool equipped = slot.EquipItem(item);
            if (equipped)
            {
                Items.Remove(item);
            }    
            return equipped;
        }

        public void UnequipItem(IEquipmentSlot slot)
        {
            if (slot.GetEquippedItem() == null)
                return;
            Items.Add(slot.UnequipItem());
        }

        public IBlueprint FindBlueprint(IBlueprint blueprint)
        {
            return Blueprints.FirstOrDefault(bp => bp.ToString() == blueprint.ToString());
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            _items = new List<string>();
            foreach (IItem item in Items)
            {
                _items.Add(item.ToString());
            }

            _blueprints = new List<string>();
            foreach (IBlueprint blueprint in Blueprints)
            {
                _blueprints.Add(blueprint.ToString());
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Items = new List<IItem>();
            IItemBuilderGenerator itemGenerator = new ItemBuilderGenerator();
            foreach (string item in _items)
            {
                Items.Add(itemGenerator.Generate(item));
            }

            Blueprints = new List<IBlueprint>();
            IBlueprintBuilder blueprintBuilder = new BlueprintBuilder();
            foreach (string blueprint in _blueprints)
            {
                Blueprints.Add(blueprintBuilder.BuildBlueprint(blueprint));
            }
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
