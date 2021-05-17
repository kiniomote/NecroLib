using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class MagicModifierSet : IMagicModifierSet
    {
        private List<IMagicModifier> _modifiers;

        private IBattleUnit _unit;
        private IBattleUnit _targetUnit;
        private IBattleCourse _battleCourse;

        protected int _range;
        protected int _width;
        protected bool? _targetType;
        protected bool _withoutTargets;
        protected TemporaryEffect _effectCountdown;

        public MagicModifierSet(int range, int width, bool? targetType, List<IMagicModifier> modifiers, TemporaryEffect effectCountdown, bool withoutTargets = false)
        {
            _range = range;
            _width = width;
            _targetType = targetType;
            _modifiers = modifiers;
            _effectCountdown = effectCountdown;
            _withoutTargets = withoutTargets;
        }

        public void SetTargets(IBattleUnit unit, IBattleUnit targetUnit, IBattleCourse battleCourse)
        {
            _unit = unit;
            _targetUnit = targetUnit;
            _battleCourse = battleCourse;
        }

        public void Actions()
        {
            foreach (IMagicModifier modifier in _modifiers)
            {
                modifier.Actions(_unit, _targetUnit, _battleCourse);
            }
        }

        public int GetRange()
        {
            return _range;
        }

        public int GetWidth()
        {
            return _width;
        }

        public TemporaryEffect GetEffectCountdown()
        {
            return _effectCountdown;
        }

        public bool? GetTargetType()
        {
            return _targetType;
        }

        public bool WithoutTargets()
        {
            return _withoutTargets;
        }
    }
}
