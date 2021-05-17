using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum BodyItem
    {
        Beginning=0,
        FelRobe=1,
        RottenSilkMantle=2,
        ReapersRobe=3,
        GhostlyHope=4,
        RunedMantle=5,
        RisenFromAshes=6,
        FirstNecromancer=7
    }

    public class BodyItemBuilder : ItemBuilder<BodyItem>
    {
        protected override Dictionary<BodyItem, string> ITEMS { get { return LocalizationNames.BODY_ITEMS; } }
        protected override Dictionary<BodyItem, string> IMAGES { get { return ImagePaths.BODY_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Body; } }

        protected override Dictionary<BodyItem, int> LEVELS { get { return new Dictionary<BodyItem, int>()
        {
            [BodyItem.Beginning] =          1,
            [BodyItem.FelRobe] =            2,
            [BodyItem.RottenSilkMantle] =   3,
            [BodyItem.ReapersRobe] =        4,
            [BodyItem.GhostlyHope] =        5,
            [BodyItem.RunedMantle] =        6,
            [BodyItem.RisenFromAshes] =     7,
            [BodyItem.FirstNecromancer] =   8,
        }; } }

        protected override Dictionary<BodyItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<BodyItem, IItemCharacteristicSet>()
        {
            [BodyItem.Beginning] =          new ItemCharacteristicSet(0, 3, 1, 0, 0, 0, 0, 0),
            [BodyItem.FelRobe] =            new ItemCharacteristicSet(0, 3, 3, 1, 0, 0, 0, 0),
            [BodyItem.RottenSilkMantle] =   new ItemCharacteristicSet(0, 8, 1, 1, 0, 0, 0, 0),
            [BodyItem.ReapersRobe] =        new ItemCharacteristicSet(1, 8, 3, 0, 0, 0, 2, 0),
            [BodyItem.GhostlyHope] =        new ItemCharacteristicSet(0, 10, 0, 6, 0, 0, 0, 2),
            [BodyItem.RunedMantle] =        new ItemCharacteristicSet(2, 12, 3, 3, 0, 0, 1, 2),
            [BodyItem.RisenFromAshes] =     new ItemCharacteristicSet(0, 16, 4, 4, 4, 0, 0, 0),
            [BodyItem.FirstNecromancer] =   new ItemCharacteristicSet(4, 18, 4, 4, 1, 1, 1, 1),
        }; } }

        protected override Dictionary<BodyItem, IWorth> WORTHS { get { return new Dictionary<BodyItem, IWorth>()
        {
            [BodyItem.Beginning] =          new Worth(new Price(250, 0, 1500, 0, 0)),
            [BodyItem.FelRobe] =            new Worth(new Price(700, 0, 4200, 0, 0)),
            [BodyItem.RottenSilkMantle] =   new Worth(new Price(1725, 0, 0, 18000, 0)),
            [BodyItem.ReapersRobe] =        new Worth(new Price(5000, 0, 0, 42000, 0)),
            [BodyItem.GhostlyHope] =        new Worth(new Price(8250, 0, 0, 79800, 0)),
            [BodyItem.RunedMantle] =        new Worth(new Price(15800, 0, 0, 145800, 4800)),
            [BodyItem.RisenFromAshes] =     new Worth(new Price(25000, 0, 0, 305200, 8400)),
            [BodyItem.FirstNecromancer] =   new Worth(new Price(42000, 0, 0, 536400, 14580)),
        }; } }
        protected override Dictionary<BodyItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<BodyItem, IBlueprint>()
        {
            [BodyItem.Beginning] =          null,
            [BodyItem.FelRobe] =            null,
            [BodyItem.RottenSilkMantle] =   null,
            [BodyItem.ReapersRobe] =        null,
            [BodyItem.GhostlyHope] =        null,
            [BodyItem.RunedMantle] =        null,
            [BodyItem.RisenFromAshes] =     null,
            [BodyItem.FirstNecromancer] =   new Blueprint(BlueprintItem.FirstNecro),
        }; } }
    }
}
