using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;
using NecroLib.Models.Localization;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Images;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum NeckItem
    {
        PebblesOnRope=0,
        PearlNeck=1,
        SilkwormCocoon=2,
        AmuletOfShadows=3,
        SpecterOfVenge=4,
        RottenDragonTeeth=5,
        LostSouls=6,
        ManticoreSpirit=7
    }

    public class NeckItemBuilder : ItemBuilder<NeckItem>
    {
        protected override Dictionary<NeckItem, string> ITEMS { get { return LocalizationNames.NECK_ITEMS; } }
        protected override Dictionary<NeckItem, string> IMAGES { get { return ImagePaths.NECK_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Neck; } }

        protected override Dictionary<NeckItem, int> LEVELS { get { return new Dictionary<NeckItem, int>()
        {
            [NeckItem.PebblesOnRope] =      1,
            [NeckItem.PearlNeck] =          2,
            [NeckItem.SilkwormCocoon] =     3,
            [NeckItem.AmuletOfShadows] =    4,
            [NeckItem.SpecterOfVenge] =     5,
            [NeckItem.RottenDragonTeeth] =  6,
            [NeckItem.LostSouls] =          7,
            [NeckItem.ManticoreSpirit] =    8,
        }; } }

        protected override Dictionary<NeckItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<NeckItem, IItemCharacteristicSet>()
        {
            [NeckItem.PebblesOnRope] =      new ItemCharacteristicSet(0, 0, 0, 0, 0, 0, 4, 0),
            [NeckItem.PearlNeck] =          new ItemCharacteristicSet(0, 0, 0, 0, 5, 1, 1, 0),
            [NeckItem.SilkwormCocoon] =     new ItemCharacteristicSet(0, 0, 0, 0, 0, 2, 2, 8),
            [NeckItem.AmuletOfShadows] =    new ItemCharacteristicSet(0, 1, 1, 2, 3, 3, 3, 3),
            [NeckItem.SpecterOfVenge] =     new ItemCharacteristicSet(0, 0, 4, 0, 0, 3, 9, 4),
            [NeckItem.RottenDragonTeeth] =  new ItemCharacteristicSet(1, 0, 1, 3, 2, 5, 5, 8),
            [NeckItem.LostSouls] =          new ItemCharacteristicSet(0, 0, 2, 3, 0, 6, 12, 7),
            [NeckItem.ManticoreSpirit] =    new ItemCharacteristicSet(0, 6, 0, 4, 1, 1, 9, 15),
        }; } }

        protected override Dictionary<NeckItem, IWorth> WORTHS { get { return new Dictionary<NeckItem, IWorth>()
        {
            [NeckItem.PebblesOnRope] =      new Worth(new Price(250, 0, 1500, 0, 0)),
            [NeckItem.PearlNeck] =          new Worth(new Price(700, 0, 4200, 0, 0)),
            [NeckItem.SilkwormCocoon] =     new Worth(new Price(1725, 0, 8550, 18000, 0)),
            [NeckItem.AmuletOfShadows] =    new Worth(new Price(5000, 0, 22125, 42000, 0)),
            [NeckItem.SpecterOfVenge] =     new Worth(new Price(8250, 0, 37350, 79800, 0)),
            [NeckItem.RottenDragonTeeth] =  new Worth(new Price(15800, 0, 71400, 145800, 4800)),
            [NeckItem.LostSouls] =          new Worth(new Price(25000, 0, 119250, 305200, 8400)),
            [NeckItem.ManticoreSpirit] =    new Worth(new Price(42000, 0, 192600, 536400, 14580)),
        }; } }
        protected override Dictionary<NeckItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<NeckItem, IBlueprint>()
        {
            [NeckItem.PebblesOnRope] =      null,
            [NeckItem.PearlNeck] =          null,
            [NeckItem.SilkwormCocoon] =     null,
            [NeckItem.AmuletOfShadows] =    null,
            [NeckItem.SpecterOfVenge] =     null,
            [NeckItem.RottenDragonTeeth] =  null,
            [NeckItem.LostSouls] =          null,
            [NeckItem.ManticoreSpirit] =    new Blueprint(BlueprintItem.ManticoreSpirit),
        }; } }
    }
}
