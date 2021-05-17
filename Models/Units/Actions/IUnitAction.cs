using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Units.Abilities;

namespace NecroLib.Models.Units.Actions
{
    public enum UnitAction
    {
        Move=0,
        Attack=1,
        Magic=2,
    }

    public interface IUnitAction
    {
        IUnitAbility UnitAbility { get; set; }
        void Prepare(IBattlePoint targetPoint, IBattleCourse battleCourse);
        List<IBattlePoint> PossiblePoints(IBattlefield battlefield);
        UnitAction GetTypeUnitAction();
        bool Realease();
        bool IsRepeat();
        bool IsEnable();
    }
}
