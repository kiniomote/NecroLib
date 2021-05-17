using NecroLib.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters.Items
{
    public enum SlotType
    {
        Head=0,
        Body=1,
        Weapon=2,
        LeftRing=3,
        RightRing=4,
        Neck=5
    }

    public interface IEquipmentSlot : INameable
    {
        bool EquipItem(IItem item);
        bool CanEquipItem(IItem item);
        IItem UnequipItem();

        IItem GetEquippedItem();
        ItemType GetSlotType();

        void SetEnoughLevelEvent(EnoughLevelHandler enoughLevelHandler);
    }
}
