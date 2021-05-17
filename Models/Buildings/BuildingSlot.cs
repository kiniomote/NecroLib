using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public abstract class BuildingSlot
    {
        protected int _level;
        protected int _numberUpgrades;

        protected abstract void BuildBuilding();

        // Getters

        public int GetLevel()
        {
            return _level;
        }

        public int GetNumberUpgrades()
        {
            return _numberUpgrades;
        }
    }
}
