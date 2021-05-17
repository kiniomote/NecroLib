using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Units.UnitBuilder;
using NecroLib.Models.Resources;
using System.Runtime.Serialization;

namespace NecroLib.Models.Units
{
    [Serializable]
    public class Squad : ISquad
    {
        private int _count;
        private int _maxSize;
        private int _missingUnitPower;

        [NonSerialized]
        private IUnit _unit;

        private SquadType _squadType;

        public UnitLevel UnitLevel { get; private set; }

        public Squad(SquadType squadType, int baseUnitPower, UnitLevel unitLevel = UnitLevel.Common)
        {
            _count = 0;
            _maxSize = 0;
            _missingUnitPower = baseUnitPower;
            _squadType = squadType;
            UnitLevel = unitLevel;
            BuildUnit();
        }

        public void IncreaseSizeSquad(int unitPower)
        {
            int count = (unitPower + _missingUnitPower) / _unit.Power.GetPower();
            _missingUnitPower = (unitPower + _missingUnitPower) % _unit.Power.GetPower();
            _maxSize += count;
        }

        public void UpgradeUnitLevel(UnitLevel unitLevel)
        {
            if (unitLevel == UnitLevel)
                return;
            UnitLevel = unitLevel;
            BuildUnit();
        }

        public void HireUnits(IResourcePack resources, int count)
        {
            _unit.Worth.Buy(resources, count);
            _count += count;
        }

        public bool CanHire(IResourcePack resources, int count)
        {
            return GetFreeSlots() >= count && _unit.Worth.EnoughResources(resources, count);
        }

        public IPrice GetRequiredResources(int count)
        {
            return _unit.Worth.GetPrice(count);
        }

        private void BuildUnit()
        {
            IUnitBuilderGenerator generator = new UnitBuilderGenerator();
            _unit = generator.GetBuilder(_squadType).BuildUnit(UnitLevel);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BuildUnit();
        }

        // Getters

        public int GetSizeUnitsAfterUpgrade(int unitPower)
        {
            int count = (unitPower + _missingUnitPower) / _unit.Power.GetPower();
            return _maxSize + count;
        }

        public int GetFreeSlots()
        {
            return _maxSize - _count;
        }

        public IUnit GetUnit()
        {
            return _unit;
        }

        public int GetCountUnits()
        {
            return _count;
        }

        public int GetSizeSquad()
        {
            return _maxSize;
        }

        public SquadType GetSquadType()
        {
            return _squadType;
        }
    }
}
