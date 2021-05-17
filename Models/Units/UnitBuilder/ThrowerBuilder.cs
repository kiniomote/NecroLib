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
    public class ThrowerBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.Thrower; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.Thrower]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 200,
            [ResourceType.Rot] = 40,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 75,
            [UnitCharacteristic.Attack] = 70,
            [UnitCharacteristic.Armor] = 70,
            [UnitCharacteristic.RangeAttack] = 5,
            [UnitCharacteristic.FlightSpeed] = 12,
            [UnitCharacteristic.MovementSpeed] = 100,
            [UnitCharacteristic.AttackSpeed] = 130,
            [UnitCharacteristic.MinDamage] = 8,
            [UnitCharacteristic.MaxDamage] = 12,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 100,
            [UnitCharacteristic.Attack] = 90,
            [UnitCharacteristic.Armor] = 90,
            [UnitCharacteristic.RangeAttack] = 5,
            [UnitCharacteristic.FlightSpeed] = 12,
            [UnitCharacteristic.MovementSpeed] = 100,
            [UnitCharacteristic.AttackSpeed] = 130,
            [UnitCharacteristic.MinDamage] = 10,
            [UnitCharacteristic.MaxDamage] = 14,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Range; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new RangeAttackAbility(),
            new PoisonAttackAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new PoisonAttackAbility(),
        }; } }
    }
}
