using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public interface IMoveModifier
    {
        void ActionsBefore(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse);
        int ModifyMoveSpeed(int moveSpeed, IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse);
        void ActionsAfter(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse);
    }
}
