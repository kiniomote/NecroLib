using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;

namespace NecroLib.Models.Battles
{
    public interface IBattleUnitEffectSet
    {
        bool RemoveEffect(IUnitTemporaryEffect effect);
        bool RemoveEffect(TemporaryEffect effectType);
        void AddEffect(IUnitTemporaryEffect effect);
        void AddEffects(List<IUnitTemporaryEffect> effects);

        int ProccessCharacteristic(int value, UnitCharacteristic characteristic);
        int GetArmorByDamageType(int value, DamageType damageType);
        bool AllowDoAction(UnitAction action);
        bool HasEffect(TemporaryEffect effect);
        List<IUnitTemporaryEffect> GetEffects();
    }
}
