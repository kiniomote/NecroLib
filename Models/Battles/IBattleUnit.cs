using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles
{
    public interface IBattleUnit
    {
        IBattleSquad Squad { get; }
        IUnit Unit { get; }
        IBattler Owner { get; }

        IAvailableActionSet Actions { get; }
        IBattleUnitEffectSet Effects { get; }

        IBattlePoint BattlePoint { get; }
        void Moved(IBattlePoint battlePoint);

        int GetUnitCharacteristic(UnitCharacteristic characteristic);
        int ApplyDamage(int damage, int attack, DamageType damageType);
        void Heal(int heal);
        bool IsEnemy(IBattleUnit battleUnit);
        void CheckDeath();

        int GetCount();
        int GetSize();
        int GetCurrentHealth();
        bool IsDead();
    }
}
