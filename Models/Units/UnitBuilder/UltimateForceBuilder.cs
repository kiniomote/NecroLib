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
    public class UltimateForceBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.UltimateForce; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.UltimateForce]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 5000,
            [ResourceType.Rot] = 1000,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 500,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 3000,
            [UnitCharacteristic.Attack] = 200,
            [UnitCharacteristic.Armor] = 200,
            [UnitCharacteristic.RangeAttack] = 1,
            [UnitCharacteristic.FlightSpeed] = 0,
            [UnitCharacteristic.MovementSpeed] = 120,
            [UnitCharacteristic.AttackSpeed] = 100,
            [UnitCharacteristic.MinDamage] = 280,
            [UnitCharacteristic.MaxDamage] = 320,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Magic; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new CurseAttackAbility(),
            new NegativeImpulseAbility(),
        }; } }
    }
}
