using NecroLib.Models.Characters;
using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public delegate void UpgradeBuildingAttributes(int level, int numberImprovement);

    public class Improvement : IImprovement
    {
        private const int FIRST_NUMBER_OF_IMPROVEMENT = 1;
        private const int NUMBER_INCREMENT_IMPROVEMENT = 1;

        private int _currentLevel;
        private int _currentNumberOfImprovement;
        private int _minLevel;
        private int _maxLevel;

        private Dictionary<int, int> _maxImprovements;
        private Dictionary<int, IPrice> _basePrices;
        private Dictionary<int, IPrice> _incrementPrices;

        private event UpgradeBuildingAttributes UpgradeBuildingAttributesHandler;

        public Improvement(Dictionary<int, int> maxImprovements, Dictionary<int, IPrice> basePrices, Dictionary<int, IPrice> incrementPrices, int currentLevel, int currentNumberOfImprovement = 0)
        {
            _maxImprovements = maxImprovements;
            _basePrices = basePrices;
            _incrementPrices = incrementPrices;
            _currentLevel = currentLevel;
            _currentNumberOfImprovement = currentNumberOfImprovement;
            FindMaxMinLevels();
        }

        public void Improve(IResourcePack resources, ILevel level)
        {
            if (!CanImprove(resources, level))
                throw new Exception("Not enough resources or level building");
            resources.SpendResources(GetImprovementPrice());
            UpdateCurrentImprovement();
            UpgradeBuildingAttributesHandler(_currentLevel, _currentNumberOfImprovement);
        }

        public bool CanImprove(IResourcePack resources, ILevel level)
        {
            if (GetNextImprovementLevel() > _maxLevel)
                return false;
            bool enoughLevel = level.GetLevel() >= GetNextImprovementLevel();
            bool enoughResources = resources.EnoughResources(GetImprovementPrice());
            bool availableLevel = GetNextImprovementLevel() <= _maxLevel && GetNextImprovementLevel() >= _minLevel;

            return enoughLevel && enoughResources && availableLevel;
        }

        public void SetUpgradeDelegate(UpgradeBuildingAttributes upgrade)
        {
            UpgradeBuildingAttributesHandler = upgrade;
        }

        private void UpdateCurrentImprovement()
        {
            if (GetNextImprovementLevel() > _maxLevel)
                return;
            int level = _currentLevel;
            _currentLevel += (_currentNumberOfImprovement == GetMaxNumberOfImprovement()) ? NUMBER_INCREMENT_IMPROVEMENT : 0;
            _currentNumberOfImprovement = (level == _currentLevel) ? _currentNumberOfImprovement + NUMBER_INCREMENT_IMPROVEMENT : FIRST_NUMBER_OF_IMPROVEMENT;
        }

        private void FindMaxMinLevels()
        {
            int minLevel = Level.MAX_LEVEL;
            int maxLevel = 0;
            foreach (var level in _maxImprovements.Keys)
            {
                if (level > maxLevel)
                    maxLevel = level;
                if (level < minLevel)
                    minLevel = level;
            }
            _minLevel = minLevel;
            _maxLevel = maxLevel;
        }

        // Getters

        public int GetValueOfUpgrade(int level, int numberUpgrade, Dictionary<int, int> valuePerUpgrade)
        {
            int additionalMining = 0;

            for (int i = _minLevel; i < level; i++)
            {
                additionalMining += valuePerUpgrade[i] * _maxImprovements[i];
            }
            additionalMining += valuePerUpgrade[level] * numberUpgrade;
            return additionalMining;
        }

        public IPrice GetImprovementPrice()
        {
            if (GetNextImprovementLevel() > _maxLevel)
                return null;
            int level = GetNextImprovementLevel();
            int numberOfImprovement = (level == _currentLevel) ? _currentNumberOfImprovement + NUMBER_INCREMENT_IMPROVEMENT : FIRST_NUMBER_OF_IMPROVEMENT;
            return _basePrices[level].GetSumPrices(new Price(_incrementPrices[level], numberOfImprovement));
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public int GetNextImprovementLevel()
        {
            if (_currentNumberOfImprovement < GetMaxNumberOfImprovement())
                return _currentLevel;
            else
                return _currentLevel + 1;
        }

        public int GetNumberOfImprovement()
        {
            return _currentNumberOfImprovement;
        }

        public int GetMaxNumberOfImprovement()
        {
            return _maxImprovements[_currentLevel];
        }

        public int GetMinLevel()
        {
            return _minLevel;
        }

        public int GetMaxLevel()
        {
            return _maxLevel;
        }
    }
}
