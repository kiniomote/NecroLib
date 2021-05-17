using NecroLib.Models.Items;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Characters.Items
{
    public interface IInventory : INameable
    {
        IEquipmentSet Equipments { get; }
        List<IItem> Items { get; }
        List<IBlueprint> Blueprints { get; }

        List<IItem> GetItemsByFilter(ItemType itemType = ItemType.All, int level = Inventory.NO_LEVEL_FILTER);

        bool EquipItem(IItem item, IEquipmentSlot slot);
        void UnequipItem(IEquipmentSlot slot);

        IBlueprint FindBlueprint(IBlueprint blueprint);
    }
}
