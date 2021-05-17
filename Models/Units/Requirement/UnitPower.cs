using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units.Require
{
    public class UnitPower : IUnitPower
    {
        public static readonly Dictionary<SquadType, int> InitSquadsUnitPower = new Dictionary<SquadType, int>()
        {
            [SquadType.LightInfantry] = 500,
            [SquadType.Archer] = 500,
            [SquadType.HeavyInfantry] = 700,
            [SquadType.Magic] = 700,
            [SquadType.Cavalry] = 1100,
            [SquadType.Thrower] = 1100,
            [SquadType.SpecialForce] = 3200,
            [SquadType.Support] = 3200,
            [SquadType.UltimateForce] = 12100,
        };


        public static readonly Dictionary<SquadType, int> SquadsUnitPower = new Dictionary<SquadType, int>()
        {
            [SquadType.LightInfantry] = 10,
            [SquadType.Archer] = 15,
            [SquadType.HeavyInfantry] = 30,
            [SquadType.Magic] = 20,
            [SquadType.Cavalry] = 50,
            [SquadType.Thrower] = 40,
            [SquadType.SpecialForce] = 150,
            [SquadType.Support] = 100,
            [SquadType.UltimateForce] = 1000,
        };

        private int _power;

        public UnitPower(int power)
        {
            _power = power;
        }

        public int GetPower()
        {
            return _power;
        }

        public static int GetSizeSquad(SquadType squadType, int power)
        {
            int fullPower = InitSquadsUnitPower[squadType];
            fullPower += power;
            return fullPower / SquadsUnitPower[squadType];
        }
    }
}
