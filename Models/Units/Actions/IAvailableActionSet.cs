using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions
{
    public interface IAvailableActionSet
    {
        List<IUnitAction> GetAvailableActions();
    }
}
