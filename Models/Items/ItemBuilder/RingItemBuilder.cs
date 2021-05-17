using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Images;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum RingItem
    {
        CopperRing=0,
        BoneRing=1,
        SpiderRing=2,
        ExecutionersLuck=3,
        WhisperOfPain=4,
        RunedRing=5,
        BloodPact=6,
        QueenOfMaggots=7,

        StoneRing=8,
        DeadManRing=9,
        MalachiteRing=10,
        Stalker=11,
        IceShard=12,
        GhoulMaster=13,
        EndlessNight=14,
        GiftOfGoola=15,
    }

    public class RingItemBuilder : ItemBuilder<RingItem>
    {
        protected override Dictionary<RingItem, string> ITEMS { get { return LocalizationNames.RING_ITEMS; } }
        protected override Dictionary<RingItem, string> IMAGES { get { return ImagePaths.RING_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Ring; } }

        protected override Dictionary<RingItem, int> LEVELS { get { return new Dictionary<RingItem, int>()
        {
            [RingItem.CopperRing] =         1,
            [RingItem.BoneRing] =           2,
            [RingItem.SpiderRing] =         3,
            [RingItem.ExecutionersLuck] =   4,
            [RingItem.WhisperOfPain] =      5,
            [RingItem.RunedRing] =          6,
            [RingItem.BloodPact] =          7,
            [RingItem.QueenOfMaggots] =     8,

            [RingItem.StoneRing] =          1,
            [RingItem.DeadManRing] =        2,
            [RingItem.MalachiteRing] =      3,
            [RingItem.Stalker] =            4,
            [RingItem.IceShard] =           5,
            [RingItem.GhoulMaster] =        6,
            [RingItem.EndlessNight] =       7,
            [RingItem.GiftOfGoola] =        8,
        }; } }

        protected override Dictionary<RingItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<RingItem, IItemCharacteristicSet>()
        {
            [RingItem.CopperRing] =         new ItemCharacteristicSet(0, 0, 0, 0, 1, 3, 0, 0),
            [RingItem.BoneRing] =           new ItemCharacteristicSet(0, 0, 0, 0, 2, 2, 3, 0),
            [RingItem.SpiderRing] =         new ItemCharacteristicSet(0, 0, 0, 0, 2, 4, 4, 0),
            [RingItem.ExecutionersLuck] =   new ItemCharacteristicSet(1, 0, 0, 0, 0, 5, 4, 4),
            [RingItem.WhisperOfPain] =      new ItemCharacteristicSet(0, 0, 2, 0, 2, 8, 2, 4),
            [RingItem.RunedRing] =          new ItemCharacteristicSet(0, 0, 2, 1, 4, 6, 8, 2),
            [RingItem.BloodPact] =          new ItemCharacteristicSet(1, 0, 1, 2, 4, 10, 4, 6),
            [RingItem.QueenOfMaggots] =     new ItemCharacteristicSet(0, 0, 5, 4, 4, 15, 4, 2),

            [RingItem.StoneRing] =          new ItemCharacteristicSet(0, 0, 0, 0, 3, 1, 0, 0),
            [RingItem.DeadManRing] =        new ItemCharacteristicSet(0, 0, 0, 0, 0, 4, 3, 0),
            [RingItem.MalachiteRing] =      new ItemCharacteristicSet(0, 0, 0, 0, 6, 2, 2, 0),
            [RingItem.Stalker] =            new ItemCharacteristicSet(0, 0, 2, 0, 6, 2, 2, 2),
            [RingItem.IceShard] =           new ItemCharacteristicSet(0, 0, 0, 2, 10, 2, 0, 4),
            [RingItem.GhoulMaster] =        new ItemCharacteristicSet(0, 1, 2, 0, 10, 5, 0, 5),
            [RingItem.EndlessNight] =       new ItemCharacteristicSet(0, 0, 4, 0, 14, 2, 4, 4),
            [RingItem.GiftOfGoola] =        new ItemCharacteristicSet(6, 0, 3, 0, 14, 3, 6, 2),
        }; } }

        protected override Dictionary<RingItem, IWorth> WORTHS { get { return new Dictionary<RingItem, IWorth>()
        {
            [RingItem.CopperRing] =         new Worth(new Price(250, 0, 1500, 0, 0)),
            [RingItem.BoneRing] =           new Worth(new Price(700, 0, 4200, 0, 0)),
            [RingItem.SpiderRing] =         new Worth(new Price(1725, 0, 0, 18000, 0)),
            [RingItem.ExecutionersLuck] =   new Worth(new Price(5000, 0, 0, 42000, 0)),
            [RingItem.WhisperOfPain] =      new Worth(new Price(8250, 0, 0, 79800, 0)),
            [RingItem.RunedRing] =          new Worth(new Price(15800, 0, 0, 145800, 4800)),
            [RingItem.BloodPact] =          new Worth(new Price(25000, 0, 0, 305200, 8400)),
            [RingItem.QueenOfMaggots] =     new Worth(new Price(42000, 0, 0, 536400, 14580)),

            [RingItem.StoneRing] =          new Worth(new Price(250, 0, 1500, 0, 0)),
            [RingItem.DeadManRing] =        new Worth(new Price(700, 0, 4200, 0, 0)),
            [RingItem.MalachiteRing] =      new Worth(new Price(1725, 0, 0, 18000, 0)),
            [RingItem.Stalker] =            new Worth(new Price(5000, 0, 0, 42000, 0)),
            [RingItem.IceShard] =           new Worth(new Price(8250, 0, 0, 79800, 0)),
            [RingItem.GhoulMaster] =        new Worth(new Price(15800, 0, 0, 145800, 4800)),
            [RingItem.EndlessNight] =       new Worth(new Price(25000, 0, 0, 305200, 8400)),
            [RingItem.GiftOfGoola] =        new Worth(new Price(42000, 0, 0, 536400, 14580)),
        }; } }
        protected override Dictionary<RingItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<RingItem, IBlueprint>()
        {
            [RingItem.CopperRing] =         null,
            [RingItem.BoneRing] =           null,
            [RingItem.SpiderRing] =         null,
            [RingItem.ExecutionersLuck] =   null,
            [RingItem.WhisperOfPain] =      null,
            [RingItem.RunedRing] =          null,
            [RingItem.BloodPact] =          null,
            [RingItem.QueenOfMaggots] =     new Blueprint(BlueprintItem.QueenOfMaggots),

            [RingItem.StoneRing] =          null,
            [RingItem.DeadManRing] =        null,
            [RingItem.MalachiteRing] =      null,
            [RingItem.Stalker] =            null,
            [RingItem.IceShard] =           null,
            [RingItem.GhoulMaster] =        null,
            [RingItem.EndlessNight] =       null,
            [RingItem.GiftOfGoola] =        new Blueprint(BlueprintItem.GiftOfGoola),
        }; } }
    }
}
