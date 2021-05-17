using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum QuestItem
    {
        SkeletonKey=0,
    }

    public class QuestItemBuilder : ItemBuilder<QuestItem>
    {
        protected override Dictionary<QuestItem, string> ITEMS { get { return LocalizationNames.QUEST_ITEMS; } }
        protected override Dictionary<QuestItem, string> IMAGES { get { return ImagePaths.QUEST_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Quest; } }

        protected override Dictionary<QuestItem, int> LEVELS { get { return new Dictionary<QuestItem, int>()
        {
            [QuestItem.SkeletonKey] = 1,
        }; } }

        protected override Dictionary<QuestItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<QuestItem, IItemCharacteristicSet>()
        {
            [QuestItem.SkeletonKey] = null,
        }; } }

        protected override Dictionary<QuestItem, IWorth> WORTHS { get { return new Dictionary<QuestItem, IWorth>()
        {
            [QuestItem.SkeletonKey] = new Worth(new Price(200, 1000, 1000, 0, 0)),
        }; } }
        protected override Dictionary<QuestItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<QuestItem, IBlueprint>()
        {
            [QuestItem.SkeletonKey] = null,
        }; } }
    }
}
