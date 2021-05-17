using NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders;
using NecroLib.Models.Resources;
using NecroLib.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public enum Military
    {
        Cemetry=0,
        Crypt=1,
        AltarOfMagic=2,
        HorseFarm=3,
        SlimeLab=4,
        ExperimentalLab=5,
        TempleOfDeath=6,

        Crematory=7,
        ForgeOfRottenIron=8,
        GhostMansion=9,
        AncientLibrary=10,
        FieldOfDeath=11,
        PlagueSwamp=12,
        CultOfDarkness=13,
        SecretResearchDepartment=14,
    }

    public delegate void UpgradeSquadSize(int count);
    public delegate void UpgradeUnitLevel(UnitLevel level);

    public class MilitaryBuilding : Building
    {
        private Dictionary<int, int> _unitPowerPerLevel;
        public UnitLevel UnitLevel { get; private set; }
        public List<SquadType> Squads;

        private UpgradeSquadSize UpgradeSquadSizeHandler;
        private UpgradeUnitLevel UpgradeUnitLevelHandler;

        public MilitaryBuilding(IImprovement improvement, UnitLevel unitLevel, Dictionary<int, int> unitPowerPerLevel, string name, bool builded = false) 
            : base(improvement, name, builded)
        {
            _unitPowerPerLevel = unitPowerPerLevel;
            UnitLevel = unitLevel;
        }

        public void AddDelegateUpgradeSquadSize(UpgradeSquadSize upgradeSquadSize)
        {
            UpgradeSquadSizeHandler += upgradeSquadSize;
        }

        public void AddDelegateUpgradeUnitLevel(UpgradeUnitLevel upgradeUnitLevel)
        {
            UpgradeUnitLevelHandler += upgradeUnitLevel;
        }

        public override void Upgrade(int level, int numberImprovement)
        {
            if (!_builded)
            {
                UpgradeUnitLevelHandler?.Invoke(UnitLevel);
                _builded = true;
            }
            UpgradeSquadSizeHandler(_unitPowerPerLevel[level]);
        }

        public int GetUnitPower()
        {
            return _builded ? Improvement.GetValueOfUpgrade(Improvement.GetCurrentLevel(), Improvement.GetNumberOfImprovement(), _unitPowerPerLevel) : 0;
        }

        public int GetNextUnitPower()
        {
            int nextLevel = Improvement.GetNextImprovementLevel();
            int numberUpgrade = Improvement.GetNumberOfImprovement();
            return Improvement.GetValueOfUpgrade(nextLevel, nextLevel == Improvement.GetCurrentLevel() ? numberUpgrade + 1 : numberUpgrade, _unitPowerPerLevel);
        }
    }
}
