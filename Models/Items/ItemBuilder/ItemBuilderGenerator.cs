using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public class ItemBuilderGenerator : IItemBuilderGenerator
    {
        public IItem Generate(string localizationName)
        {
            IItem item = null;
            if (localizationName == string.Empty)
                return item;
            foreach (var head in LocalizationNames.HEAD_ITEMS)
            {
                if (head.Value == localizationName)
                {
                    return new HeadItemBuilder().BuildItem(head.Key);
                }
            }
            foreach (var body in LocalizationNames.BODY_ITEMS)
            {
                if (body.Value == localizationName)
                {
                    return new BodyItemBuilder().BuildItem(body.Key);
                }
            }
            foreach (var weapon in LocalizationNames.WEAPON_ITEMS)
            {
                if (weapon.Value == localizationName)
                {
                    return new WeaponItemBuilder().BuildItem(weapon.Key);
                }
            }
            foreach (var neck in LocalizationNames.NECK_ITEMS)
            {
                if (neck.Value == localizationName)
                {
                    return new NeckItemBuilder().BuildItem(neck.Key);
                }
            }
            foreach (var ring in LocalizationNames.RING_ITEMS)
            {
                if (ring.Value == localizationName)
                {
                    return new RingItemBuilder().BuildItem(ring.Key);
                }
            }
            return item;
        }
    }
}
