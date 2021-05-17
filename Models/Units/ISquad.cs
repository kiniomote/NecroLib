using NecroLib.Models.Localization;
using NecroLib.Models.Resources;
using NecroLib.Models.Characters.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Units
{
    public enum SquadType
    {
        LightInfantry=0,
        HeavyInfantry=1,
        Cavalry=2,
        SpecialForce=3,
        Archer=4,
        Thrower=5,
        UltimateForce=6,
        Magic=7,
        Support=8,
    }

    public interface ISquad
    {
        UnitLevel UnitLevel { get; }

        int GetSizeUnitsAfterUpgrade(int unitPower);
        int GetCountUnits();
        int GetSizeSquad();
        int GetFreeSlots();
        SquadType GetSquadType();

        void IncreaseSizeSquad(int count);
        void UpgradeUnitLevel(UnitLevel unitLevel);
        IUnit GetUnit();

        void HireUnits(IResourcePack resources, int count);
        bool CanHire(IResourcePack resources, int count);
        IPrice GetRequiredResources(int count);
    }
}
