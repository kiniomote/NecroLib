using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;
using NecroLib.Models.Localization;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Images;

namespace NecroLib.Models.Items.ItemBuilder
{
    public enum WeaponItem
    {
        PineStaff=0,
        MetalStaff=1,
        StaffOfDecay=2,
        AncientBoneStaff=3,
        RodOfStrife=4,
        DeadLegionsWand=5,
        ScepterOfOldMonarch=6,
        HarbringerOfDeath=7
    }

    public class WeaponItemBuilder : ItemBuilder<WeaponItem>
    {
        protected override Dictionary<WeaponItem, string> ITEMS { get { return LocalizationNames.WEAPON_ITEMS; } }
        protected override Dictionary<WeaponItem, string> IMAGES { get { return ImagePaths.WEAPON_ITEMS; } }

        protected override ItemType TYPE { get { return ItemType.Weapon; } }

        protected override Dictionary<WeaponItem, int> LEVELS { get { return new Dictionary<WeaponItem, int>()
        {
            [WeaponItem.PineStaff] =            1,
            [WeaponItem.MetalStaff] =           2,
            [WeaponItem.StaffOfDecay] =         3,
            [WeaponItem.AncientBoneStaff] =     4,
            [WeaponItem.RodOfStrife] =          5,
            [WeaponItem.DeadLegionsWand] =      6,
            [WeaponItem.ScepterOfOldMonarch] =  7,
            [WeaponItem.HarbringerOfDeath] =    8,
        }; } }

        protected override Dictionary<WeaponItem, IItemCharacteristicSet> CHARACTERISTICS { get { return new Dictionary<WeaponItem, IItemCharacteristicSet>()
        {
            [WeaponItem.PineStaff] =            new ItemCharacteristicSet(3, 0, 0, 1, 0, 0, 0, 0),
            [WeaponItem.MetalStaff] =           new ItemCharacteristicSet(5, 2, 0, 0, 0, 0, 0, 0),
            [WeaponItem.StaffOfDecay] =         new ItemCharacteristicSet(8, 0, 2, 2, 0, 0, 0, 0),
            [WeaponItem.AncientBoneStaff] =     new ItemCharacteristicSet(9, 1, 1, 1, 2, 0, 0, 2),
            [WeaponItem.RodOfStrife] =          new ItemCharacteristicSet(10, 0, 4, 2, 0, 1, 3, 0),
            [WeaponItem.DeadLegionsWand] =      new ItemCharacteristicSet(14, 2, 2, 2, 0, 2, 3, 0),
            [WeaponItem.ScepterOfOldMonarch] =  new ItemCharacteristicSet(15, 0, 4, 6, 0, 4, 1, 0),
            [WeaponItem.HarbringerOfDeath] =    new ItemCharacteristicSet(20, 0, 6, 6, 2, 2, 0, 0),
        }; } }

        protected override Dictionary<WeaponItem, IWorth> WORTHS { get { return new Dictionary<WeaponItem, IWorth>()
        {
            [WeaponItem.PineStaff] =            new Worth(new Price(250, 0, 1500, 0, 0)),
            [WeaponItem.MetalStaff] =           new Worth(new Price(700, 0, 4200, 0, 0)),
            [WeaponItem.StaffOfDecay] =         new Worth(new Price(1725, 0, 8550, 18000, 0)),
            [WeaponItem.AncientBoneStaff] =     new Worth(new Price(5000, 0, 22125, 42000, 0)),
            [WeaponItem.RodOfStrife] =          new Worth(new Price(8250, 0, 37350, 79800, 0)),
            [WeaponItem.DeadLegionsWand] =      new Worth(new Price(15800, 0, 71400, 145800, 4800)),
            [WeaponItem.ScepterOfOldMonarch] =  new Worth(new Price(25000, 0, 119250, 305200, 8400)),
            [WeaponItem.HarbringerOfDeath] =    new Worth(new Price(42000, 0, 192600, 536400, 14580)),
        }; } }
        protected override Dictionary<WeaponItem, IBlueprint> BLUEPRINTS { get { return new Dictionary<WeaponItem, IBlueprint>()
        {
            [WeaponItem.PineStaff] =            null,
            [WeaponItem.MetalStaff] =           null,
            [WeaponItem.StaffOfDecay] =         null,
            [WeaponItem.AncientBoneStaff] =     null,
            [WeaponItem.RodOfStrife] =          null,
            [WeaponItem.DeadLegionsWand] =      null,
            [WeaponItem.ScepterOfOldMonarch] =  null,
            [WeaponItem.HarbringerOfDeath] =    new Blueprint(BlueprintItem.HarbringerOfDeath),
        }; } }
    }
}
