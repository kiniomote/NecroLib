using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public interface IItemBuilder<T>
    {
        CrafteItem BuildCrafteItem(T item);
        IItem BuildItem(T item);
    }
}
