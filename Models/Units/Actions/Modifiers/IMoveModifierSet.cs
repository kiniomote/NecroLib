using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IMoveModifierSet
    {
        void SetTargets(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse);

        void ActionsBefore();
        int ModifyMoveSpeed(int moveSpeed);
        void ActionsAfter();
    }
}
