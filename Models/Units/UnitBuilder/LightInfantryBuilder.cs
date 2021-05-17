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
    public class LightInfantryBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.LightInfantry; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.LightInfantry]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 50,
            [ResourceType.Rot] = 10,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 50,
            [UnitCharacteristic.Attack] = 50,
            [UnitCharacteristic.Armor] = 50,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 100,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 4,
            [UnitCharacteristic.MaxDamage] = 6,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 65,
            [UnitCharacteristic.Attack] = 60,
            [UnitCharacteristic.Armor] = 70,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 100,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 5,
            [UnitCharacteristic.MaxDamage] = 7,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Melee; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new TightRowsAttackAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new TightRowsAttackAbility(),
            new SteelWallAttackAbility(),
        }; } }
    }
}
