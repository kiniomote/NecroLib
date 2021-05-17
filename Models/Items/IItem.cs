using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Items
{
    public enum ItemType
    {
        All=-1, // Only for filter
        Head=0,
        Body=1,
        Weapon=2,
        Ring=3,
        Neck=4,
        Quest=5,
    }

    public interface IItem : INameable, IDescribeable, IImageable
    {
        IItemCharacteristicSet Characteristics { get; }

        int GetItemLevel();
        ItemType GetItemType();
    }
}
