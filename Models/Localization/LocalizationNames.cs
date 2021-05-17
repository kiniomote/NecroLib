using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Buildings;
using NecroLib.Models.Characters;
using NecroLib.Models.Characters.Items;
using NecroLib.Models.Dialogs;
using NecroLib.Models.Items.BlueprintBuilder;
using NecroLib.Models.Items.ItemBuilder;
using NecroLib.Models.Items;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Localization
{
    public static class LocalizationNames
    {
        public const string NAME = "_name";
        public const string DESCRIPTION = "_description";

        #region Labels

        public const string MENU_LABEL = "Label_menu";
        public const string COST_LABEL = "Label_cost";
        public const string ABILITIES_LABEL = "Label_abilities";

        public const string NOW_GRADE_BUILDING_LABEL = "Label_now_grade";
        public const string NEXT_GRADE_BUILDING_LABEL = "Label_next_grade";

        public const string LEVEL_LABEL = "Label_level";
        public const string FREE_STATS_LABEL = "Label_free_stats";
        public const string BATTLE_STATS_LABEL = "Label_battle_stats";
        public const string MINING_STATS_LABEL = "Label_mining_stats";
        public const string UPGRADE_SKILLS_LABEL = "Label_upgrade_skills";
        public const string INVENTORY_LABEL = "Label_inventory";
        public const string INFO_LABEL = "Label_info_item";

        public const string BLUEPRINT_LABEL = "Label_blueprint";

        public const string CHARACTERISTICS_LABEL = "Label_unit_characteristics";
        public const string STATS_LABEL = "Label_unit_stats";

        public const string RESOURCES_LABEL = "Label_resources";

        public const string PER_HOUR = "Label_per_hour";

        #endregion

        #region Buttons

        public const string BUILD_BUTTON = "Button_build";
        public const string UPGRADE_BUTTON = "Button_upgrade";
        public const string CRAFT_BUTTON = "Button_craft";
        public const string HIRE_BUTTON = "Button_hire";
        public const string UNEQUIP_BUTTON = "Button_unequip";
        public const string CONTINUE_BUTTON = "Button_continue";
        public const string START_BUTTON = "Button_start";
        public const string SAVE_BUTTON = "Button_save";
        public const string SETTINGS_BUTTON = "Button_settings";
        public const string LANGUAGE_BUTTON = "Button_language";
        public const string EXIT_BUTTON = "Button_exit";
        public const string BACK_BUTTON = "Button_back";
        public const string FIGHT_BUTTON = "Button_fight";
        public const string OK_BUTTON = "Button_ok";

        #endregion

        #region Buildings

        public const string MINING_QUARTER_NAME = "Building_mining_quarter_name";
        public const string MILITARY_QUARTER_NAME = "Building_military_quarter_name";

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

        public const string ARMY = "Unit_army_name";

        public static readonly Dictionary<UnitCharacteristic, string> UNIT_CHARACTERISTICS = new Dictionary<UnitCharacteristic, string>()
        {
            [UnitCharacteristic.Health] = "Unit_stat_health",
            [UnitCharacteristic.Attack] = "Unit_stat_attack",
            [UnitCharacteristic.Armor] = "Unit_stat_armor",
            [UnitCharacteristic.AttackSpeed] = "Unit_stat_attack_speed",
            [UnitCharacteristic.FlightSpeed] = "Unit_stat_flight_speed",
            [UnitCharacteristic.MovementSpeed] = "Unit_stat_move_speed",
            [UnitCharacteristic.RangeAttack] = "Unit_stat_range_attack",
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

        #endregion

        #region Resources

        public static readonly Dictionary<ResourceType, string> RESOURCES_NAMES = new Dictionary<ResourceType, string>()
        {
            [ResourceType.Rot] = "Resource_rot",
            [ResourceType.Stone] = "Resource_stone",
            [ResourceType.Metal] = "Resource_metal",
            [ResourceType.Silk] = "Resource_silk",
            [ResourceType.Rune] = "Resource_rune"
        };

        #endregion

        #region Characters

        public const string INVENTORY = "Character_inventory_name";
        public const string EQUIPMENT = "Character_equipment_name";
        public const string HERO_CHARACTERISTICS = "Character_hero_characteristics_name";

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

        #region Items

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
            [RingItem.StoneRing] = "Item_ring_level_1_2",

            [RingItem.BoneRing] = "Item_ring_level_2_1",
            [RingItem.DeadManRing] = "Item_ring_level_2_2",

            [RingItem.SpiderRing] = "Item_ring_level_3_1",
            [RingItem.MalachiteRing] = "Item_ring_level_3_2",

            [RingItem.ExecutionersLuck] = "Item_ring_level_4_1",
            [RingItem.Stalker] = "Item_ring_level_4_2",

            [RingItem.WhisperOfPain] = "Item_ring_level_5_1",
            [RingItem.IceShard] = "Item_ring_level_5_2",

            [RingItem.RunedRing] = "Item_ring_level_6_1",
            [RingItem.GhoulMaster] = "Item_ring_level_6_2",

            [RingItem.BloodPact] = "Item_ring_level_7_1",
            [RingItem.EndlessNight] = "Item_ring_level_7_2",

            [RingItem.QueenOfMaggots] = "Item_ring_level_8_1",
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

        public static readonly Dictionary<ItemType, string> ITEM_TYPES = new Dictionary<ItemType, string>()
        {
            [ItemType.Head] = "Item_type_head",
            [ItemType.Body] = "Item_type_body",
            [ItemType.Weapon] = "Item_type_weapon",
            [ItemType.Neck] = "Item_type_neck",
            [ItemType.Ring] = "Item_type_ring",
        };

        #endregion

        #region Dialogs

        public static readonly Dictionary<Speakers, string> SPEAKERS = new Dictionary<Speakers, string>()
        {
            [Speakers.Main] = "Dialog_speaker_main",
            [Speakers.Skull] = "Dialog_speaker_skull",
            [Speakers.Tailor] = "Dialog_speaker_tailor",
        };

        #endregion

        #region Levels

        public static readonly List<string> LEVEL_NAMES = new List<string>()
        {
            "Character_level_0",
            "Character_level_1", "Character_level_2", "Character_level_3", "Character_level_4",
            "Character_level_5", "Character_level_6", "Character_level_7", "Character_level_8"
        };

        #endregion

        #region Quests

        public const string QUEST = "Quest";

        #endregion
    }
}
