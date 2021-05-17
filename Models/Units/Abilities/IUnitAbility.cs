using NecroLib.Models.Localization;
using NecroLib.Models.Battles;
using NecroLib.Models.Images;
using NecroLib.Models.Units.Actions.Modifiers;
using NecroLib.Models.Units.Actions;
using NecroLib.Models.Units.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Abilities
{
    public enum UnitAbilities
    {
        PoisonAttack,
        TightRows,
        LiveShield,
        MagicArmor,
        SteelWall,
        Charger,
        Executioner,
        MasterOfMelee,
        CloackOfShadow,
        AuraOfRot,
        TentacleGrip,
        CallOfNecromancer,
        CoverOfDarkness,
        FrostNova,
        Blizzard,
        CurseAttack,
        NegativeImpulse,
        RangeAttack,
    }

    public interface IUnitAbility : INameable, IDescribeable, IIconable
    {
        void AddAttackModifierTo(List<IAttackModifier> attackModifiers);
        void AddMoveModifierTo(List<IMoveModifier> moveModifiers);
        void AddAdditionalActions(List<IUnitAction> unitActions, IBattleUnit battleUnit);
        void AddEffects(IBattleUnit battleUnit);
        TemporaryEffect? GetCountDownEffect();
    }
}
