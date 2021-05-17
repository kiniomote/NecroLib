using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Actions
{
    public class AvailableActionSet : IAvailableActionSet
    {
        private List<IUnitAction> _actions;

        public AvailableActionSet(List<IUnitAction> actions)
        {
            _actions = actions;
        }

        public List<IUnitAction> GetAvailableActions()
        {
            return _actions;
        }
    }
}
