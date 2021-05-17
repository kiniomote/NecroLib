using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public abstract class MoveModifier : IMoveModifier
    {
        public virtual void ActionsAfter(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse)
        {

        }

        public virtual int ModifyMoveSpeed(int moveSpeed, IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            return moveSpeed;
        }

        public virtual void ActionsBefore(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse)
        {

        }
    }
}
