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
    public class CavalryBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.Cavalry; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.Cavalry]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 250,
            [ResourceType.Rot] = 50,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 150,
            [UnitCharacteristic.Attack] = 100,
            [UnitCharacteristic.Armor] = 60,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 140,
            [UnitCharacteristic.AttackSpeed] = 110,
            [UnitCharacteristic.MinDamage] = 18,
            [UnitCharacteristic.MaxDamage] = 20,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 150,
            [UnitCharacteristic.Attack] = 120,
            [UnitCharacteristic.Armor] = 100,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 140,
            [UnitCharacteristic.AttackSpeed] = 110,
            [UnitCharacteristic.MinDamage] = 20,
            [UnitCharacteristic.MaxDamage] = 22,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Melee; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new ChargerAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new ChargerAbility(),
            new ExecutionerAttackAbility(),
        }; } }
    }
}
