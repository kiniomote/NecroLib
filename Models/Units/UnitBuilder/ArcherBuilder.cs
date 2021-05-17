using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;
using NecroLib.Models.Units.Require;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Abilities;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Units.UnitBuilder
{
    public class ArcherBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.Archer; } } 
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.Archer]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 75,
            [ResourceType.Rot] = 15,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 40,
            [UnitCharacteristic.Attack] = 60,
            [UnitCharacteristic.Armor] = 35,
            [UnitCharacteristic.RangeAttack] = 3,
            [UnitCharacteristic.FlightSpeed] = 8,
            [UnitCharacteristic.MovementSpeed] = 80,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 5,
            [UnitCharacteristic.MaxDamage] = 8,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 40,
            [UnitCharacteristic.Attack] = 75,
            [UnitCharacteristic.Armor] = 50,
            [UnitCharacteristic.RangeAttack] = 5,
            [UnitCharacteristic.FlightSpeed] = 8,
            [UnitCharacteristic.MovementSpeed] = 80,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 7,
            [UnitCharacteristic.MaxDamage] = 9,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Range; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new RangeAttackAbility(),
            new TightRowsAttackAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new RangeAttackAbility(),
            new TightRowsAttackAbility(),
            new CloackOfShadowAbility(),
        }; } }
    }
}
