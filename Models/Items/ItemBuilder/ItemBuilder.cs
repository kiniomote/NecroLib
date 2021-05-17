using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public abstract class ItemBuilder<T> : IItemBuilder<T>
    {
        protected virtual Dictionary<T, string> ITEMS { get; }
        protected virtual Dictionary<T, string> IMAGES { get; }

        protected virtual Dictionary<T, int> LEVELS { get; }
        protected virtual ItemType TYPE { get; }

        protected virtual Dictionary<T, IItemCharacteristicSet> CHARACTERISTICS { get; }

        protected virtual Dictionary<T, IWorth> WORTHS { get; }
        protected virtual Dictionary<T, IBlueprint> BLUEPRINTS { get; }

        public IItem BuildItem(T item)
        {
            string name = ITEMS[item];
            string description = ITEMS[item];
            int level = LEVELS[item];
            ItemType type = TYPE;
            IItemCharacteristicSet characteristics = CHARACTERISTICS[item];
            IItem newItem = new Item(level, type, characteristics, name);
            newItem.Image = new ImagePath(IMAGES[item]);
            return newItem;
        }

        public CrafteItem BuildCrafteItem(T item)
        {
            string name = ITEMS[item];
            int level = LEVELS[item];
            ItemType type = TYPE;
            IItemCharacteristicSet characteristics = CHARACTERISTICS[item];
            IWorth worth = WORTHS[item];
            IBlueprint blueprint = BLUEPRINTS[item];
            CrafteItem crafteItem = new CrafteItem(level, type, characteristics, name, worth, blueprint);
            crafteItem.Image = new ImagePath(IMAGES[item]);
            return crafteItem;
        }
    }
}
