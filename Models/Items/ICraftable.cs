using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Characters.Items;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Items
{
    public interface ICraftable
    {
        IBlueprint RequiredBlueprint { get; }

        IItem CraftItem(IInventory inventory, IResourcePack resources);
        bool HasBlueprint(IInventory inventory);
        bool HasResources(IResourcePack resource);
        IPrice GetRequiredResources();
    }
}
