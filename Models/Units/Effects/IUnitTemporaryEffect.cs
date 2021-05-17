using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Battles;
using NecroLib.Models.Images;

namespace NecroLib.Models.Units.Effects
{
    public enum TemporaryEffect
    {
        PoisonMove = 0,
        LiveShield = 1,
        FrozenMove = 2,
        Stunned = 3,
        MagicArmor = 4,
        ChargerMove = 5,
        FrostNovaCountdown = 6,
        CloackOfShadowCountdown = 7,
        AuraOfRotFriend = 8,
        AuraOfRotCountdown = 9,
        TentacleGripCountdown = 10,
        CoverOfDarkness = 11,
        CoverOfDarknessCountdown = 12,
        BlizzardCountdown = 13,
        CallOfNecromancerCountdown = 14,
        Curse = 15,
        NegativeImpulseCountdown = 16,
        AuraOfRotEnemy = 17,
        CloackOfShadow = 18,
    }

    public interface IUnitTemporaryEffect : IIconable
    {
        IBattleUnit BattleUnit { get; }
        TemporaryEffect GetEffectType();

        bool IsEqual(IUnitTemporaryEffect effect);
        int GetModifyCharacteristic(UnitCharacteristic characteristic, int value);
        int GetArmorByDamageType(int value, DamageType damageType);
        bool AllowDoAction(UnitAction action);
    }
}
