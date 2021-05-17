using NecroLib.Models.Characters;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public interface IImprovement
    {
        void Improve(IResourcePack resources, ILevel level);
        bool CanImprove(IResourcePack resources, ILevel level);

        int GetValueOfUpgrade(int level, int numberUpgrade, Dictionary<int, int> valuePerUpgrade);
        IPrice GetImprovementPrice();
        int GetCurrentLevel();
        int GetNextImprovementLevel();
        int GetNumberOfImprovement();
        int GetMaxNumberOfImprovement();

        int GetMinLevel();
        int GetMaxLevel();

        void SetUpgradeDelegate(UpgradeBuildingAttributes upgrade);
    }
}
