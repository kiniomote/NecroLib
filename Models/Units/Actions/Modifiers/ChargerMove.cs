using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Units.Effects;
using NecroLib.Models.Units.Stats;
using NecroLib.Models.Battles.Battlefields;

namespace NecroLib.Models.Units.Actions.Modifiers
{
    public class ChargerMove : MoveModifier
    {
        public override void ActionsAfter(IBattleUnit unit, IBattlePoint targetPoint, IBattleCourse battleCourse)
        {
            _ = new Charger(unit);
        }
    }
}
