using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Buildings.BuildingBuilder.MilitaryBuilders;
using NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders;

namespace NecroLib.Models.Buildings.BuildingBuilder
{
    public class BuildingBuilderGenerator : IBuildingBuilderGenerator
    {
        private Dictionary<Mining, IMiningBuildingBuilder> _miningBuilders = new Dictionary<Mining, IMiningBuildingBuilder>()
        {
            [Mining.Main] = new MainMiningBuildingBuilder(),
            [Mining.StoneQuarry] = new StoneMiningBuildingBuilder(),
            [Mining.CursedIronMine] = new MetalMiningBuildingBuilder(),
            [Mining.RottenSilkFactory] = new SilkMiningBuildingBuilder(),
            [Mining.RunesWorkshop] = new RuneMiningBuildingBuilder(),
        };

        private Dictionary<Military, IMilitaryBuildingBuilder> _militaryBuilders = new Dictionary<Military, IMilitaryBuildingBuilder>()
        {
            [Military.Cemetry] = new CemetryMilitaryBuildingBuilder(),
            [Military.Crypt] = new CryptMilitaryBuildingBuilder(),
            [Military.AltarOfMagic] = new AltarMilitaryBuildingBuilder(),
            [Military.HorseFarm] = new HorseMilitaryBuildingBuilder(),
            [Military.SlimeLab] = new SlimeMilitaryBuildingBuilder(),
            [Military.TempleOfDeath] = new TempleMilitaryBuildingBuilder(),
            [Military.ExperimentalLab] = new ExperimentalMilitaryBuildingBuilder(),

            [Military.Crematory] = new CrematoryMilitaryBuildingBuilder(),
            [Military.ForgeOfRottenIron] = new ForgeMilitaryBuildingBuilder(),
            [Military.GhostMansion] = new MansionMilitaryBuildingBuilder(),
            [Military.AncientLibrary] = new LibraryMilitaryBuildingBuilder(),
            [Military.FieldOfDeath] = new FieldMilitaryBuildingBuilder(),
            [Military.PlagueSwamp] = new SwampMilitaryBuildingBuilder(),
            [Military.CultOfDarkness] = new CultMilitaryBuildingBuilder(),
            [Military.SecretResearchDepartment] = new SecretMilitaryBuildingBuilder(),
        };

        public IMiningBuildingBuilder GetBuilder(Mining mining)
        {
            return _miningBuilders[mining];
        }

        public IMilitaryBuildingBuilder GetBuilder(Military military)
        {
            return _militaryBuilders[military];
        }
    }
}
