using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Characters;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Battles
{
    public class BattleUnit : IBattleUnit
    {
        public IBattleSquad Squad { get; private set; }
        public IUnit Unit { get; private set; }
        public IBattler Owner { get; private set; }

        public IAvailableActionSet Actions { get; private set; }
        public IBattleUnitEffectSet Effects { get; private set; }

        public IBattlePoint BattlePoint { get; private set; }

        private int _currentHealth;
        private int _count;
        private int _size;

        private bool _dead;

        public BattleUnit(IBattleSquad squad, Dictionary<HeroAttribute, int> attributes, IBattler battler)
        {
            Unit = squad.BuildUnit();
            Squad = squad;
            Owner = battler;
            Effects = new BattleUnitEffectSet();
            _size = squad.GetSizeSquad();
            _count = squad.GetCountUnits();
            _currentHealth = Unit.Characteristics.Health.GetValue();
            _dead = false;
            AddHeroStatsToUnit(attributes);
            ProccessAbilitiesToUnit();
        }

        public int GetUnitCharacteristic(UnitCharacteristic characteristic)
        {
            return Effects.ProccessCharacteristic(Unit.Characteristics.GetCharacteristicValue(characteristic), characteristic);
        }

        public int ApplyDamage(int damage, int attack, DamageType damageType)
        {
            int unitHealth = GetUnitCharacteristic(UnitCharacteristic.Health);
            int armor = Unit.Characteristics.GetCharacteristicValue(UnitCharacteristic.Armor);
            int realDamage = Damage.CalculateDamage(damage, attack, Effects.GetArmorByDamageType(armor, damageType));

            int diedUnit = realDamage / unitHealth;
            int damageHealth = realDamage % unitHealth;

            if (_currentHealth <= damageHealth)
            {
                diedUnit++;
                damageHealth -= _currentHealth;
                _currentHealth = unitHealth - damageHealth;
            }
            else
            {
                _currentHealth -= damageHealth;
            }

            _count -= diedUnit;

            return realDamage;
        }

        public void Heal(int heal)
        {
            int rised = heal / GetUnitCharacteristic(UnitCharacteristic.Health);
            int healed = heal % GetUnitCharacteristic(UnitCharacteristic.Health);

            if (_currentHealth + healed > GetUnitCharacteristic(UnitCharacteristic.Health))
            {
                if (GetCount() + rised >= GetSize())
                {
                    _currentHealth = GetUnitCharacteristic(UnitCharacteristic.Health);
                }
                else
                {
                    _currentHealth = _currentHealth + healed - GetUnitCharacteristic(UnitCharacteristic.Health);
                    rised++;
                }
            }

            _count = GetCount() + ((GetCount() + rised) < GetSize() ? GetCount() + rised : GetSize());
        }

        public void CheckDeath()
        {
            if (_count <= 0)
            {
                BattlePoint.MoveIn(null);
                BattlePoint = null;
                _dead = true;
            }
        }

        public bool IsEnemy(IBattleUnit battleUnit)
        {
            return battleUnit.Owner == Owner ? Battlefield.FRIEND : Battlefield.ENEMY;
        }

        public void Moved(IBattlePoint battlePoint)
        {
            BattlePoint = battlePoint;
        }

        public int GetCount()
        {
            return _count;
        }

        public int GetSize()
        {
            return _size;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public bool IsDead()
        {
            return _dead;
        }

        private void AddHeroStatsToUnit(Dictionary<HeroAttribute, int> attributes)
        {
            Unit.Characteristics.Attack.Modify(attributes[HeroAttribute.Attack]);
            Unit.Characteristics.Armor.Modify(attributes[HeroAttribute.Armor]);
            Unit.Characteristics.AttackSpeed.Modify(attributes[HeroAttribute.AttackSpeed]);
            Unit.Characteristics.MovementSpeed.Modify(attributes[HeroAttribute.MovementSpeed]);
        }

        private void ProccessAbilitiesToUnit()
        {
            Actions = Unit.Abilities.GetActions(this);
        }
    }
}
