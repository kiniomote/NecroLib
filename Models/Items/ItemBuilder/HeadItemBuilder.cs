using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Images;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum HeadItem
    {
        OldHood=0,
        FuneraryHood=1,
        RottenSilkHood=2,
        Blackness=3,
        PaganHood=4,
        RunnedHood=5,
        JestersCurse=6,
        HorroMaker=7
    }

    public class HeadItemBuilder : ItemBuilder<HeadItem>
    {
        protected override Dictionary<HeadItem, string> ITEMS { get { return LocalizationNames.HEAD_ITEMS; } }
        protected override Dictionary<HeadItem, string> IMAGES { get { return ImagePaths.HEAD_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Head; } }

        protected override Dictionary<HeadItem, int> LEVELS { get { return new Dictionary<HeadItem, int>()
        {
            [HeadItem.OldHood] =        1,
            [HeadItem.FuneraryHood] =   2,
            [HeadItem.RottenSilkHood] = 3,
            [HeadItem.Blackness] =      4,
            [HeadItem.PaganHood] =      5,
            [HeadItem.RunnedHood] =     6,
            [HeadItem.JestersCurse] =   7,
            [HeadItem.HorroMaker] =     8,
        }; } }

        protected override Dictionary<HeadItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<HeadItem, IItemCharacteristicSet>()
        {
            [HeadItem.OldHood] =        new ItemCharacteristicSet(0, 0, 2, 2, 0, 0, 0, 0),
            [HeadItem.FuneraryHood] =   new ItemCharacteristicSet(0, 0, 2, 5, 0, 0, 0, 0),
            [HeadItem.RottenSilkHood] = new ItemCharacteristicSet(0, 0, 5, 5, 0, 0, 0, 0),
            [HeadItem.Blackness] =      new ItemCharacteristicSet(0, 1, 4, 8, 0, 1, 0, 0),
            [HeadItem.PaganHood] =      new ItemCharacteristicSet(4, 4, 4, 4, 2, 0, 0, 0),
            [HeadItem.RunnedHood] =     new ItemCharacteristicSet(1, 3, 8, 8, 2, 0, 1, 0),
            [HeadItem.JestersCurse] =   new ItemCharacteristicSet(6, 6, 6, 6, 0, 0, 0, 4),
            [HeadItem.HorroMaker] =     new ItemCharacteristicSet(0, 6, 12, 12, 0, 0, 2, 2),
        }; } }

        protected override Dictionary<HeadItem, IWorth> WORTHS { get { return new Dictionary<HeadItem, IWorth>()
        {
            [HeadItem.OldHood] =        new Worth(new Price(250, 0, 1500, 0, 0)),
            [HeadItem.FuneraryHood] =   new Worth(new Price(700, 0, 4200, 0, 0)),
            [HeadItem.RottenSilkHood] = new Worth(new Price(1725, 0, 0, 18000, 0)),
            [HeadItem.Blackness] =      new Worth(new Price(5000, 0, 0, 42000, 0)),
            [HeadItem.PaganHood] =      new Worth(new Price(8250, 0, 0, 79800, 0)),
            [HeadItem.RunnedHood] =     new Worth(new Price(15800, 0, 0, 145800, 4800)),
            [HeadItem.JestersCurse] =   new Worth(new Price(25000, 0, 0, 305200, 8400)),
            [HeadItem.HorroMaker] =     new Worth(new Price(42000, 0, 0, 536400, 14580)),
        }; } }
        protected override Dictionary<HeadItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<HeadItem, IBlueprint>()
        {
            [HeadItem.OldHood] =        null,
            [HeadItem.FuneraryHood] =   null,
            [HeadItem.RottenSilkHood] = null,
            [HeadItem.Blackness] =      null,
            [HeadItem.PaganHood] =      null,
            [HeadItem.RunnedHood] =     null,
            [HeadItem.JestersCurse] =   null,
            [HeadItem.HorroMaker] =     new Blueprint(BlueprintItem.HorrorMaker),
        }; } }
    }
}
