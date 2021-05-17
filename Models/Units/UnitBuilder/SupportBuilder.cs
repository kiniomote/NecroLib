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
    public class SupportBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.Support; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.Support]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 500,
            [ResourceType.Rot] = 100,
            [ResourceType.Silk] = 300,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 200,
            [UnitCharacteristic.Attack] = 100,
            [UnitCharacteristic.Armor] = 85,
            [UnitCharacteristic.RangeAttack] = 4,
            [UnitCharacteristic.FlightSpeed] = 5,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 115,
            [UnitCharacteristic.MinDamage] = 20,
            [UnitCharacteristic.MaxDamage] = 25,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 240,
            [UnitCharacteristic.Attack] = 110,
            [UnitCharacteristic.Armor] = 100,
            [UnitCharacteristic.RangeAttack] = 4,
            [UnitCharacteristic.FlightSpeed] = 5,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 115,
            [UnitCharacteristic.MinDamage] = 25,
            [UnitCharacteristic.MaxDamage] = 30,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Magic; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new CallOfNecromancerAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>()
        {
            new CallOfNecromancerAbility(),
            new CoverOfDarknessAbility(),
        }; } }
    }
}
