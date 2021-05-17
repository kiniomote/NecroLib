using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public delegate List<CrafteItem> GetItems();

    public class CrafteItemBuilder : ICrafteItemBuilder
    {
        private readonly Dictionary<ItemType, GetItems> _getters;

        public CrafteItemBuilder()
        {
            _getters = new Dictionary<ItemType, GetItems>()
            {
                [ItemType.Head] = GetHeads,
                [ItemType.Body] = GetBodies,
                [ItemType.Weapon] = GetWeapons,
                [ItemType.Ring] = GetRings,
                [ItemType.Neck] = GetNecks,
            };
        }

        public List<CrafteItem> GetAllCrafteItems()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();

            foreach (var crafteItem in _getters)
            {
                crafteItems.AddRange(GetCrafteItems(crafteItem.Key));
            }

            return crafteItems;
        }

        public List<CrafteItem> GetCrafteItems(ItemType itemType)
        {
            return _getters[itemType].Invoke();
        }

        private List<CrafteItem> GetHeads()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.HEAD_ITEMS)
            {
                crafteItems.Add(new HeadItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }

        private List<CrafteItem> GetBodies()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.BODY_ITEMS)
            {
                crafteItems.Add(new BodyItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }

        private List<CrafteItem> GetWeapons()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.WEAPON_ITEMS)
            {
                crafteItems.Add(new WeaponItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }

        private List<CrafteItem> GetRings()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.RING_ITEMS)
            {
                crafteItems.Add(new RingItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }

        private List<CrafteItem> GetNecks()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.NECK_ITEMS)
            {
                crafteItems.Add(new NeckItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }

        private List<CrafteItem> GetQuests()
        {
            List<CrafteItem> crafteItems = new List<CrafteItem>();
            foreach (var item in LocalizationNames.QUEST_ITEMS)
            {
                crafteItems.Add(new QuestItemBuilder().BuildCrafteItem(item.Key));
            }
            return crafteItems;
        }
    }
}
