using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Characters;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings
{
    public interface IBuildingSlot
    {
        int GetNumberUpgrades();
        int GetLevel();

        void BuildOrUpgrade(IResourcePack resources, ILevel level);
        bool CanBuildOrUpgrade(IResourcePack resources, ILevel level);
        IPrice GetBuildOrUpgradePrice();
    }
}
