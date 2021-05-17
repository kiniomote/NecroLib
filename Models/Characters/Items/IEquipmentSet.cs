using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Items;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters.Items
{
    public interface IEquipmentSet : INameable
    {
        Dictionary<SlotType, IEquipmentSlot> EquipmentSlots { get; }

        List<IEquipmentSlot> AvailableItemSlots(IItem item);

        int GetItemSetBattleCharacteristic(HeroAttribute attribute);
        int GetItemSetMiningCharacteristic(HeroAttribute attribute);
    }
}
