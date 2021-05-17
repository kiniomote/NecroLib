using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public interface ICrafteItemBuilder
    {
        List<CrafteItem> GetAllCrafteItems();
        List<CrafteItem> GetCrafteItems(ItemType itemType);
    }
}
