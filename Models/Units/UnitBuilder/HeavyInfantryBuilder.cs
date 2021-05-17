using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Require;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units.UnitBuilder
{
    public class HeavyInfantryBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.HeavyInfantry; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.HeavyInfantry]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 150,
            [ResourceType.Rot] = 30,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 140,
            [UnitCharacteristic.Attack] = 75,
            [UnitCharacteristic.Armor] = 75,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 10,
            [UnitCharacteristic.MaxDamage] = 14,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 170,
            [UnitCharacteristic.Attack] = 85,
            [UnitCharacteristic.Armor] = 120,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 12,
            [UnitCharacteristic.MaxDamage] = 16,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Melee; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new LiveShieldAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new LiveShieldAbility(),
            new MagicArmorAbility(),
        }; } }
    }
}
