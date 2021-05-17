using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Units;
using NecroLib.Models.Units.UnitBuilder;
using System.Runtime.Serialization;

namespace NecroLib.Models.Battles
{
    [Serializable]
    public class BattleSquad : IBattleSquad
    {
        private int _count;
        private int _maxSize;

        public IImagePath Image { get; set; }

        private SquadType _squadType;

        public UnitLevel UnitLevel { get; private set; }

        public BattleSquad(SquadType squadType, int count, UnitLevel unitLevel = UnitLevel.Common)
        {
            _count = count;
            _maxSize = count;
            _squadType = squadType;
            UnitLevel = unitLevel;
            switch (UnitLevel)
            {
                case UnitLevel.Common:
                    Image = new ImagePath(ImagePaths.COMMON_SQUAD[_squadType], ImagePaths.ICON_IMAGE);
                    break;
                case UnitLevel.FirstUpgraded:
                    Image = new ImagePath(ImagePaths.FIRST_UPGRADED_SQUAD[_squadType], ImagePaths.ICON_IMAGE);
                    break;
            }
        }

        public BattleSquad(ISquad squad)
        {
            _count = squad.GetCountUnits();
            _maxSize = squad.GetCountUnits();
            _squadType = squad.GetSquadType();
            UnitLevel = squad.UnitLevel;
        }

        public IUnit BuildUnit()
        {
            IUnitBuilderGenerator generator = new UnitBuilderGenerator();
            return generator.GetBuilder(_squadType).BuildUnit(UnitLevel);
        }

        // Getters

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
