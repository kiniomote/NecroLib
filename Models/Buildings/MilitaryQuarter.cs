using NecroLib.Models.Units;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using NecroLib.Models.Localization;
using NecroLib.Models.Images;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public class MilitaryQuarter : IMilitaryQuarter
    {
        protected LocalizedString _name;

        private readonly Dictionary<Military, int> _militariesLevels = new Dictionary<Military, int>()
        {
            [Military.Cemetry] = 1, 
            [Military.Crypt] = 2, 
            [Military.AltarOfMagic] = 2, 
            [Military.HorseFarm] = 3, 
            [Military.SlimeLab] = 3, 
            [Military.Crematory] = 4,
            [Military.ForgeOfRottenIron] = 4, 
            [Military.ExperimentalLab] = 5,
            [Military.TempleOfDeath] = 5, 
            [Military.GhostMansion] = 6, 
            [Military.AncientLibrary] = 6, 
            [Military.FieldOfDeath] = 7, 
            [Military.PlagueSwamp] = 7, 
            [Military.CultOfDarkness] = 8, 
            [Military.SecretResearchDepartment] = 8,
        };

        private IArmy _army;

        public IImagePath IconImage { get; set; }

        public Dictionary<Military, MilitaryBuildingSlot> BuildingSlots { get; private set; }

        public MilitaryQuarter(IArmy army)
        {
            _army = army;
            BuildingSlots = new Dictionary<Military, MilitaryBuildingSlot>();
            _militariesLevels.Keys.ToList().ForEach(military => BuildingSlots.Add(military, new MilitaryBuildingSlot(military, _militariesLevels[military])));
            _name = new LocalizedString(LocalizationNames.MILITARY_QUARTER_NAME);
            SetUpgradeSquadDelegates();
            SetUpgradeUnitLevelDelegates();
            IconImage = new ImagePath(ImagePaths.MILITARY_QUARTER, ImagePaths.ICON_IMAGE);
        }

        private void SetUpgradeSquadDelegates()
        {
            BuildingSlots[Military.Cemetry].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.LightInfantry].IncreaseSizeSquad);
            BuildingSlots[Military.Cemetry].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Archer].IncreaseSizeSquad);
            BuildingSlots[Military.Crypt].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.HeavyInfantry].IncreaseSizeSquad);
            BuildingSlots[Military.HorseFarm].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Cavalry].IncreaseSizeSquad);
            BuildingSlots[Military.SlimeLab].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Thrower].IncreaseSizeSquad);
            BuildingSlots[Military.AltarOfMagic].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Magic].IncreaseSizeSquad);
            BuildingSlots[Military.TempleOfDeath].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Support].IncreaseSizeSquad);
            BuildingSlots[Military.ExperimentalLab].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.SpecialForce].IncreaseSizeSquad);

            BuildingSlots[Military.ForgeOfRottenIron].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.LightInfantry].IncreaseSizeSquad);
            BuildingSlots[Military.Crematory].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Archer].IncreaseSizeSquad);
            BuildingSlots[Military.GhostMansion].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.HeavyInfantry].IncreaseSizeSquad);
            BuildingSlots[Military.FieldOfDeath].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Cavalry].IncreaseSizeSquad);
            BuildingSlots[Military.PlagueSwamp].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Thrower].IncreaseSizeSquad);
            BuildingSlots[Military.AncientLibrary].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Magic].IncreaseSizeSquad);
            BuildingSlots[Military.CultOfDarkness].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.Support].IncreaseSizeSquad);
            BuildingSlots[Military.SecretResearchDepartment].Building.AddDelegateUpgradeSquadSize(_army.Squads[SquadType.UltimateForce].IncreaseSizeSquad);
        }

        private void SetUpgradeUnitLevelDelegates()
        {
            BuildingSlots[Military.ForgeOfRottenIron].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.LightInfantry].UpgradeUnitLevel);
            BuildingSlots[Military.Crematory].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.Archer].UpgradeUnitLevel);
            BuildingSlots[Military.GhostMansion].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.HeavyInfantry].UpgradeUnitLevel);
            BuildingSlots[Military.FieldOfDeath].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.Cavalry].UpgradeUnitLevel);
            BuildingSlots[Military.PlagueSwamp].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.Thrower].UpgradeUnitLevel);
            BuildingSlots[Military.AncientLibrary].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.Magic].UpgradeUnitLevel);
            BuildingSlots[Military.CultOfDarkness].Building.AddDelegateUpgradeUnitLevel(_army.Squads[SquadType.Support].UpgradeUnitLevel);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BuildingSlots.OnDeserialization(context);
            SetUpgradeSquadDelegates();
            SetUpgradeUnitLevelDelegates();
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
