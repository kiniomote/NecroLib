using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions.Modifiers;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units.Actions
{
    public class AttackExecuteAction : IUnitExecuteAction
    {
        public IBattlePoint TargetBattlePoint { get; private set; }
        public IBattlePoint SourceBattlePoint { get; private set; }
        public IBattleUnit BattleUnit { get; private set; }
        public IUnitAction UnitAction { get; private set; }

        private IAttackModifierSet _attackModifierSet;

        private IBattleCourse _battleCourse;

        public AttackExecuteAction(IUnitAction unitAction, IBattleUnit unit, IAttackModifierSet attackModifierSet, IBattlePoint targetBattlePoint, IBattleCourse battleCourse)
        {
            UnitAction = unitAction;
            BattleUnit = unit;
            _attackModifierSet = attackModifierSet;
            _battleCourse = battleCourse;
            TargetBattlePoint = targetBattlePoint;
            SourceBattlePoint = BattleUnit.BattlePoint;
        }

        public bool Release()
        {
            IBattleUnit target = TargetBattlePoint.BattleUnit;
            if (target == null)
                return false;

            _attackModifierSet.SetTargets(BattleUnit, target, _battleCourse);

            ActionsBefore();

            int damage = Damage.GetRandomDamage(GetMinDamage() * BattleUnit.GetCount(), GetMaxDamage() * BattleUnit.GetCount());
            int attack = GetAttack();
            DamageType damageType = BattleUnit.Unit.Characteristics.Damage.DamageType;
            target.ApplyDamage(damage, attack, damageType);

            ActionsAfter();
            return true;
        }

        private void ActionsBefore()
        {
            _attackModifierSet.ActionsBefore();
        }

        private int GetMinDamage()
        {
            int damage = BattleUnit.GetUnitCharacteristic(UnitCharacteristic.MinDamage);
            return _attackModifierSet.ModifyMinDamage(damage);
        }

        private int GetMaxDamage()
        {
            int damage = BattleUnit.GetUnitCharacteristic(UnitCharacteristic.MaxDamage);
            return _attackModifierSet.ModifyMaxDamage(damage);
        }

        private int GetAttack()
        {
            int attack = BattleUnit.GetUnitCharacteristic(UnitCharacteristic.Attack);
            return _attackModifierSet.ModifyAttack(attack);
        }

        private void ActionsAfter()
        {
            _attackModifierSet.ActionsAfter();
        }
    }
}
