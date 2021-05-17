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
    public class MagicBuilder : UnitBuilder
    {
        protected override SquadType SQUAD_TYPE { get { return SquadType.Magic; } }
        protected override int UNIT_POWER { get { return UnitPower.SquadsUnitPower[SquadType.Magic]; } }

        protected override Dictionary<ResourceType, int> RESOURCES { get { return new Dictionary<ResourceType, int>()
        {
            [ResourceType.Stone] = 0,
            [ResourceType.Metal] = 100,
            [ResourceType.Rot] = 20,
            [ResourceType.Silk] = 0,
            [ResourceType.Rune] = 0,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> COMMON_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 45,
            [UnitCharacteristic.Attack] = 70,
            [UnitCharacteristic.Armor] = 45,
            [UnitCharacteristic.RangeAttack] = 4,
            [UnitCharacteristic.FlightSpeed] = 5,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 115,
            [UnitCharacteristic.MinDamage] = 5,
            [UnitCharacteristic.MaxDamage] = 6,
        }; } }

        protected override Dictionary<UnitCharacteristic, int> FIRST_UPGRADED_CHARACTERISTICS { get { return new Dictionary<UnitCharacteristic, int>()
        {
            [UnitCharacteristic.Health] = 65,
            [UnitCharacteristic.Attack] = 80,
            [UnitCharacteristic.Armor] = 55,
            [UnitCharacteristic.RangeAttack] = 4,
            [UnitCharacteristic.FlightSpeed] = 5,
            [UnitCharacteristic.MovementSpeed] = 60,
            [UnitCharacteristic.AttackSpeed] = 115,
            [UnitCharacteristic.MinDamage] = 6,
            [UnitCharacteristic.MaxDamage] = 10,
        }; } }

        protected override DamageType DAMAGE_TYPE { get { return DamageType.Magic; } }

        protected override List<IUnitAbility> COMMON_ABILITIES { get { return new List<IUnitAbility>()
        {
            new TightRowsAttackAbility(),
            new FrostNovaAbility(),
        }; } }

        protected override List<IUnitAbility> FIRST_UPGRADED_ABILITIES { get { return new List<IUnitAbility>() 
        {
            new TightRowsAttackAbility(),
            new BlizzardAbility(),
        }; } }
    }
}
