using NecroLib.Models.Characters.Items;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items
{
    public class CrafteItem : Item, ICraftable
    {
        private IWorth _worth;
        public IBlueprint RequiredBlueprint { get; private set; }

        public CrafteItem(int level, ItemType itemType, IItemCharacteristicSet characteristics, string name, IWorth worth, IBlueprint blueprint) 
            : base(level, itemType, characteristics, name)
        {
            _worth = worth;
            RequiredBlueprint = blueprint;
        }

        public IItem CraftItem(IInventory inventory, IResourcePack resources)
        {
            if (!HasBlueprint(inventory) || !HasResources(resources))
                throw new Exception("Not enough resources or blueprint");

            if (RequiredBlueprint != null)
                inventory.Blueprints.Remove(inventory.FindBlueprint(RequiredBlueprint));

            _worth.Buy(resources);
            return this;
        }

        public bool HasBlueprint(IInventory inventory)
        {
            if (RequiredBlueprint == null)
                return true;
            return inventory.FindBlueprint(RequiredBlueprint) != null;
        }

        public bool HasResources(IResourcePack resource)
        {
            return _worth.EnoughResources(resource);
        }

        public IPrice GetRequiredResources()
        {
            return _worth.GetPrice();
        }
    }
}
