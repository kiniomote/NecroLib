using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.UnitBuilder
{
    public interface IUnitBuilderGenerator
    {
        IUnitBuilder GetBuilder(SquadType squadType);
    }
}
