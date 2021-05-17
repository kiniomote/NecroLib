using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Buildings;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Abilities;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Dialogs;
using NecroLib.Models.Characters.Items;
using NecroLib.Models.Items.ItemBuilder;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Items;
using NecroLib.Models.Characters;

namespace NecroLib.Models.Images
{
    public static class ImagePaths
    {
        #region Additional params

        public const string ICON_IMAGE = "_icon";

        #endregion

        #region Resources

        public const string RESOURCES_FOLDER = "Resources";

        public static readonly Dictionary<ResourceType, string> RESOURCES_NAMES = new Dictionary<ResourceType, string>()
        {
            [ResourceType.Rot] = "Resource_rot",
            [ResourceType.Stone] = "Resource_stone",
            [ResourceType.Metal] = "Resource_metal",
            [ResourceType.Silk] = "Resource_silk",
            [ResourceType.Rune] = "Resource_rune"
        };

        #endregion

        #region Buildings

        public const string BUILDINGS_FOLDER = "Buildings";

        public const string MINING_QUARTER = "Building_mining_quarter";
        public const string MILITARY_QUARTER = "Building_military_quarter";

        public static readonly Dictionary<Mining, string> MINING_RESOURCE_BUILDINGS = new Dictionary<Mining, string>()
        {
            [Mining.Main] = RESOURCES_NAMES[ResourceType.Rot],
            [Mining.StoneQuarry] = RESOURCES_NAMES[ResourceType.Stone],
            [Mining.CursedIronMine] = RESOURCES_NAMES[ResourceType.Metal],
            [Mining.RottenSilkFactory] = RESOURCES_NAMES[ResourceType.Silk],
            [Mining.RunesWorkshop] = RESOURCES_NAMES[ResourceType.Rune]
        };

        public static readonly Dictionary<Mining, string> MINING_BUILDINGS = new Dictionary<Mining, string>()
        {
            [Mining.Main] = "Building_mining_main",
            [Mining.StoneQuarry] = "Building_mining_stone_quarry",
            [Mining.CursedIronMine] = "Building_mining_iron_mine",
            [Mining.RottenSilkFactory] = "Building_mining_silk_factory",
            [Mining.RunesWorkshop] = "Building_mining_rune_workshop",
        };

        public static readonly Dictionary<Military, string> MILITARY_BUILDINGS = new Dictionary<Military, string>()
        {
            [Military.Cemetry] = "Building_military_cemetry",
            [Military.Crypt] = "Building_military_crypt",
            [Military.HorseFarm] = "Building_military_horse_farm",
            [Military.ExperimentalLab] = "Building_military_experimental_lab",
            [Military.SlimeLab] = "Building_military_slime_lab",
            [Military.AltarOfMagic] = "Building_military_altar_of_magic",
            [Military.TempleOfDeath] = "Building_military_temple_of_death",

            [Military.Crematory] = "Building_military_creamatory",
            [Military.ForgeOfRottenIron] = "Building_military_forge_of_iron",
            [Military.GhostMansion] = "Building_military_ghost_mansion",
            [Military.FieldOfDeath] = "Building_military_field_of_death",
            [Military.PlagueSwamp] = "Building_military_plague_swamp",
            [Military.SecretResearchDepartment] = "Building_military_secret_department",
            [Military.AncientLibrary] = "Building_military_ancient_library",
            [Military.CultOfDarkness] = "Building_military_cult_of_darkness",
        };

        #endregion

        #region Units

        public const string UNITS_FOLDER = "Units";

        public const string ARMY = "Unit_army_name";

        public static readonly Dictionary<UnitCharacteristic, string> UNIT_CHARACTERISTICS = new Dictionary<UnitCharacteristic, string>()
        {
            [UnitCharacteristic.Health] = "Unit_stat_health",
            [UnitCharacteristic.Attack] = "Unit_stat_attack",
            [UnitCharacteristic.Armor] = "Unit_stat_armor",
            [UnitCharacteristic.AttackSpeed] = "Unit_stat_attack_speed",
            [UnitCharacteristic.MovementSpeed] = "Unit_stat_move_speed",
            [UnitCharacteristic.RangeAttack] = "Unit_stat_range_attack",
            [UnitCharacteristic.FlightSpeed] = "Unit_stat_flight_speed",
            [UnitCharacteristic.Damage] = "Unit_stat_damage",
        };

        public static readonly Dictionary<SquadType, string> COMMON_SQUAD = new Dictionary<SquadType, string>()
        {
            [SquadType.LightInfantry] = "Unit_common_light_infantry",
            [SquadType.HeavyInfantry] = "Unit_common_heavy_infantry",
            [SquadType.Cavalry] = "Unit_common_cavalry",
            [SquadType.SpecialForce] = "Unit_common_special_force",
            [SquadType.Archer] = "Unit_common_archer",
            [SquadType.Thrower] = "Unit_common_thrower",
            [SquadType.UltimateForce] = "Unit_common_ultimate_force",
            [SquadType.Magic] = "Unit_common_magic",
            [SquadType.Support] = "Unit_common_support",
        };

        public static readonly Dictionary<SquadType, string> FIRST_UPGRADED_SQUAD = new Dictionary<SquadType, string>()
        {
            [SquadType.LightInfantry] = "Unit_first_upgraded_light_infantry",
            [SquadType.HeavyInfantry] = "Unit_first_upgraded_heavy_infantry",
            [SquadType.Cavalry] = "Unit_first_upgraded_cavalry",
            [SquadType.Archer] = "Unit_first_upgraded_archer",
            [SquadType.Thrower] = "Unit_first_upgraded_thrower",
            [SquadType.Magic] = "Unit_first_upgraded_magic",
            [SquadType.Support] = "Unit_first_upgraded_support",
        };

        public static readonly Dictionary<SquadType, string> COMMON_SQUAD_ATTACK = new Dictionary<SquadType, string>()
        {
            [SquadType.LightInfantry] = "Unit_attack_common_light_infantry",
            [SquadType.HeavyInfantry] = "Unit_attack_common_heavy_infantry",
            [SquadType.Cavalry] = "Unit_attack_common_cavalry",
            [SquadType.SpecialForce] = "Unit_attack_common_special_force",
            [SquadType.Archer] = "Unit_attack_common_archer",
            [SquadType.Thrower] = "Unit_attack_common_thrower",
            [SquadType.UltimateForce] = "Unit_attack_common_ultimate_force",
            [SquadType.Magic] = "Unit_attack_common_magic",
            [SquadType.Support] = "Unit_attack_common_support",
        };

        public static readonly Dictionary<SquadType, string> FIRST_UPGRADED_SQUAD_ATTACK = new Dictionary<SquadType, string>()
        {
            [SquadType.LightInfantry] = "Unit_attack_first_upgraded_light_infantry",
            [SquadType.HeavyInfantry] = "Unit_attack_first_upgraded_heavy_infantry",
            [SquadType.Cavalry] = "Unit_attack_first_upgraded_cavalry",
            [SquadType.Archer] = "Unit_attack_first_upgraded_archer",
            [SquadType.Thrower] = "Unit_attack_first_upgraded_thrower",
            [SquadType.Magic] = "Unit_attack_first_upgraded_magic",
            [SquadType.Support] = "Unit_attack_first_upgraded_support",
        };

        public static readonly Dictionary<UnitAbilities, string> UNIT_ABILITIES = new Dictionary<UnitAbilities, string>()
        {
            [UnitAbilities.PoisonAttack] = "Unit_ability_poison_attack",
            [UnitAbilities.RangeAttack] = "Unit_ability_range_attack",
            [UnitAbilities.TightRows] = "Unit_ability_tight_rows",
            [UnitAbilities.LiveShield] = "Unit_ability_live_shield",
            [UnitAbilities.MagicArmor] = "Unit_ability_magic_armor",
            [UnitAbilities.SteelWall] = "Unit_ability_steel_wall",
            [UnitAbilities.Charger] = "Unit_ability_charger",
            [UnitAbilities.Executioner] = "Unit_ability_executioner",
            [UnitAbilities.MasterOfMelee] = "Unit_ability_master_of_melee",
            [UnitAbilities.CloackOfShadow] = "Unit_ability_cloack_of_shadow",
            [UnitAbilities.AuraOfRot] = "Unit_ability_aura_of_rot",
            [UnitAbilities.TentacleGrip] = "Unit_ability_tentacle_grip",
            [UnitAbilities.CallOfNecromancer] = "Unit_ability_call_of_necromancer",
            [UnitAbilities.CoverOfDarkness] = "Unit_ability_cover_of_darkness",
            [UnitAbilities.FrostNova] = "Unit_ability_frost_nova",
            [UnitAbilities.Blizzard] = "Unit_ability_blizzard",
            [UnitAbilities.CurseAttack] = "Unit_ability_curse_attack",
            [UnitAbilities.NegativeImpulse] = "Unit_ability_negative_impulse",
        };

        public static readonly Dictionary<TemporaryEffect, string> UNIT_EFFECTS = new Dictionary<TemporaryEffect, string>()
        {
            [TemporaryEffect.PoisonMove] = "Unit_effect_poison_move",
            [TemporaryEffect.FrozenMove] = "Unit_effect_frozen_move",
            [TemporaryEffect.Stunned] = "Unit_effect_stunned",
            [TemporaryEffect.ChargerMove] = "Unit_effect_charge_move",
            [TemporaryEffect.AuraOfRotFriend] = "Unit_effect_aura_of_rot_friend",
            [TemporaryEffect.AuraOfRotEnemy] = "Unit_effect_aura_of_rot_enemy",
            [TemporaryEffect.CoverOfDarkness] = "Unit_effect_cover_of_darkness",
            [TemporaryEffect.CloackOfShadow] = "Unit_effect_cloack_of_shadow",
        };

        public static readonly Dictionary<UnitLevel, Dictionary<SquadType, string>> ATTACK_UNIT_LEVEL = new Dictionary<UnitLevel, Dictionary<SquadType, string>>()
        {
            [UnitLevel.Common] = COMMON_SQUAD_ATTACK,
            [UnitLevel.FirstUpgraded] = FIRST_UPGRADED_SQUAD_ATTACK,
        };

        #endregion

        #region Dialogs

        public const string DIALOGS_FOLDER = "Dialogs";

        public static readonly Dictionary<Speakers, string> SPEAKERS = new Dictionary<Speakers, string>()
        {
            [Speakers.Main] = "Dialog_speaker_main",
            [Speakers.Skull] = "Dialog_speaker_skull",
            [Speakers.Tailor] = "Dialog_speaker_tailor",
        };

        #endregion

        #region Items

        public const string ITEMS_FOLDER = "Items";

        public static readonly Dictionary<ItemType, string> ITEM_TYPES = new Dictionary<ItemType, string>()
        {
            [ItemType.Head] = "Item_type_head",
            [ItemType.Body] = "Item_type_body",
            [ItemType.Weapon] = "Item_type_weapon",
            [ItemType.Neck] = "Item_type_neck",
            [ItemType.Ring] = "Item_type_ring",
            [ItemType.Quest] = "Item_type_quest",
        };

        public static readonly Dictionary<SlotType, string> EQUIPMENT_SLOTS_NAMES = new Dictionary<SlotType, string>()
        {
            [SlotType.Head] = "Item_slot_head",
            [SlotType.Body] = "Item_slot_body",
            [SlotType.Weapon] = "Item_slot_weapon",
            [SlotType.LeftRing] = "Item_slot_left_ring",
            [SlotType.RightRing] = "Item_slot_right_ring",
            [SlotType.Neck] = "Item_slot_neck",
        };

        public static readonly Dictionary<HeadItem, string> HEAD_ITEMS = new Dictionary<HeadItem, string>()
        {
            [HeadItem.OldHood] = "Item_head_level_1_1",
            [HeadItem.FuneraryHood] = "Item_head_level_2_1",
            [HeadItem.RottenSilkHood] = "Item_head_level_3_1",
            [HeadItem.Blackness] = "Item_head_level_4_1",
            [HeadItem.PaganHood] = "Item_head_level_5_1",
            [HeadItem.RunnedHood] = "Item_head_level_6_1",
            [HeadItem.JestersCurse] = "Item_head_level_7_1",
            [HeadItem.HorroMaker] = "Item_head_level_8_1",
        };

        public static readonly Dictionary<BodyItem, string> BODY_ITEMS = new Dictionary<BodyItem, string>()
        {
            [BodyItem.Beginning] = "Item_body_level_1_1",
            [BodyItem.FelRobe] = "Item_body_level_2_1",
            [BodyItem.RottenSilkMantle] = "Item_body_level_3_1",
            [BodyItem.ReapersRobe] = "Item_body_level_4_1",
            [BodyItem.GhostlyHope] = "Item_body_level_5_1",
            [BodyItem.RunedMantle] = "Item_body_level_6_1",
            [BodyItem.RisenFromAshes] = "Item_body_level_7_1",
            [BodyItem.FirstNecromancer] = "Item_body_level_8_1",
        };

        public static readonly Dictionary<WeaponItem, string> WEAPON_ITEMS = new Dictionary<WeaponItem, string>()
        {
            [WeaponItem.PineStaff] = "Item_weapon_level_1_1",
            [WeaponItem.MetalStaff] = "Item_weapon_level_2_1",
            [WeaponItem.StaffOfDecay] = "Item_weapon_level_3_1",
            [WeaponItem.AncientBoneStaff] = "Item_weapon_level_4_1",
            [WeaponItem.RodOfStrife] = "Item_weapon_level_5_1",
            [WeaponItem.DeadLegionsWand] = "Item_weapon_level_6_1",
            [WeaponItem.ScepterOfOldMonarch] = "Item_weapon_level_7_1",
            [WeaponItem.HarbringerOfDeath] = "Item_weapon_level_8_1",
        };

        public static readonly Dictionary<NeckItem, string> NECK_ITEMS = new Dictionary<NeckItem, string>()
        {
            [NeckItem.PebblesOnRope] = "Item_neck_level_1_1",
            [NeckItem.PearlNeck] = "Item_neck_level_2_1",
            [NeckItem.SilkwormCocoon] = "Item_neck_level_3_1",
            [NeckItem.AmuletOfShadows] = "Item_neck_level_4_1",
            [NeckItem.SpecterOfVenge] = "Item_neck_level_5_1",
            [NeckItem.RottenDragonTeeth] = "Item_neck_level_6_1",
            [NeckItem.LostSouls] = "Item_neck_level_7_1",
            [NeckItem.ManticoreSpirit] = "Item_neck_level_8_1",
        };

        public static readonly Dictionary<RingItem, string> RING_ITEMS = new Dictionary<RingItem, string>()
        {
            [RingItem.CopperRing] = "Item_ring_level_1_1",
            [RingItem.BoneRing] = "Item_ring_level_2_1",
            [RingItem.SpiderRing] = "Item_ring_level_3_1",
            [RingItem.ExecutionersLuck] = "Item_ring_level_4_1",
            [RingItem.WhisperOfPain] = "Item_ring_level_5_1",
            [RingItem.RunedRing] = "Item_ring_level_6_1",
            [RingItem.BloodPact] = "Item_ring_level_7_1",
            [RingItem.QueenOfMaggots] = "Item_ring_level_8_1",

            [RingItem.StoneRing] = "Item_ring_level_1_2",
            [RingItem.DeadManRing] = "Item_ring_level_2_2",
            [RingItem.MalachiteRing] = "Item_ring_level_3_2",
            [RingItem.Stalker] = "Item_ring_level_4_2",
            [RingItem.IceShard] = "Item_ring_level_5_2",
            [RingItem.GhoulMaster] = "Item_ring_level_6_2",
            [RingItem.EndlessNight] = "Item_ring_level_7_2",
            [RingItem.GiftOfGoola] = "Item_ring_level_8_2",
        };

        public static readonly Dictionary<QuestItem, string> QUEST_ITEMS = new Dictionary<QuestItem, string>()
        {
            [QuestItem.SkeletonKey] = "Item_quest_level_1_1",
        };

        public static readonly Dictionary<BlueprintItem, string> BLUEPRINTS = new Dictionary<BlueprintItem, string>()
        {
            [BlueprintItem.FirstNecro] = "Item_blueprint_body_level_8_1",
            [BlueprintItem.HorrorMaker] = "Item_blueprint_head_level_8_1",
            [BlueprintItem.HarbringerOfDeath] = "Item_blueprint_weapon_level_8_1",
            [BlueprintItem.QueenOfMaggots] = "Item_blueprint_ring_level_8_1",
            [BlueprintItem.GiftOfGoola] = "Item_blueprint_ring_level_8_2",
            [BlueprintItem.ManticoreSpirit] = "Item_blueprint_neck_level_8_1",
        };

        #endregion

        #region Characters

        public const string CHARACTER_FOLDER = "Character";

        public const string CHARACTER = "Character_main";

        public static readonly Dictionary<HeroAttribute, string> BATTLE_CHARACTERISTICS = new Dictionary<HeroAttribute, string>()
        {
            [HeroAttribute.Attack] = "Character_stat_attack",
            [HeroAttribute.Armor] = "Character_stat_armor",
            [HeroAttribute.AttackSpeed] = "Character_stat_attack_speed",
            [HeroAttribute.MovementSpeed] = "Character_stat_movement_speed",
        };

        public static readonly Dictionary<HeroAttribute, string> MINING_CHARACTERISTICS = new Dictionary<HeroAttribute, string>()
        {
            [HeroAttribute.MiningStone] = "Character_stat_stone",
            [HeroAttribute.MiningMetal] = "Character_stat_metal",
            [HeroAttribute.MiningRotRune] = "Character_stat_rot_rune",
            [HeroAttribute.MiningSilk] = "Character_stat_silk",
        };

        #endregion

    }
}
