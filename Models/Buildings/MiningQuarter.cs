using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NecroLib.Models.Localization;
using System.Runtime.Serialization;
using NecroLib.Models.Resources;
using NecroLib.Models.Buildings.BuildingBuilder.MiningBuilders;
using NecroLib.Models.Images;
using System.Timers;

namespace NecroLib.Models.Buildings
{
    [Serializable]
    public class MiningQuarter : IMiningQuarter
    {
        protected LocalizedString _name;

        private readonly Dictionary<Mining, int> _miningsLevels = new Dictionary<Mining, int>()
        {
            [Mining.Main] = 1,
            [Mining.StoneQuarry] = 1,
            [Mining.CursedIronMine] = 1, 
            [Mining.RottenSilkFactory] = 3,
            [Mining.RunesWorkshop] = 6,
        };

        private IResourcePack _resourcePack;

        public IImagePath IconImage { get; set; }

        public Dictionary<Mining, MiningBuildingSlot> BuildingSlots { get; private set; }

        public DateTime LastTimeMine { get; private set; }
        [NonSerialized]
        private Timer _timer;

        public MiningQuarter(IResourcePack resourcePack)
        {
            LastTimeMine = DateTime.Now;
            _resourcePack = resourcePack;
            BuildingSlots = new Dictionary<Mining, MiningBuildingSlot>();
            _miningsLevels.Keys.ToList().ForEach(mining => BuildingSlots.Add(mining, new MiningBuildingSlot(mining, _miningsLevels[mining])));
            _name = new LocalizedString(LocalizationNames.MINING_QUARTER_NAME);
            SetMineResourceDelegates();
            IconImage = new ImagePath(ImagePaths.MINING_QUARTER, ImagePaths.ICON_IMAGE);
        }

        private void SetMineResourceDelegates()
        {
            BuildingSlots[Mining.Main].Building.Miner.AddMineEvent(_resourcePack.Resources[ResourceType.Rot].IncreaseValue);
            BuildingSlots[Mining.StoneQuarry].Building.Miner.AddMineEvent(_resourcePack.Resources[ResourceType.Stone].IncreaseValue);
            BuildingSlots[Mining.CursedIronMine].Building.Miner.AddMineEvent(_resourcePack.Resources[ResourceType.Metal].IncreaseValue);
            BuildingSlots[Mining.RottenSilkFactory].Building.Miner.AddMineEvent(_resourcePack.Resources[ResourceType.Silk].IncreaseValue);
            BuildingSlots[Mining.RunesWorkshop].Building.Miner.AddMineEvent(_resourcePack.Resources[ResourceType.Rune].IncreaseValue);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BuildingSlots.OnDeserialization(context);
            SetMineResourceDelegates();
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public void StartMining(DateTime startMining, ElapsedEventHandler saveCharacter)
        {
            foreach (var mining in BuildingSlots.Values)
            {
                mining.Building.Miner.StartMining(LastTimeMine, startMining);
            }

            _timer = new Timer(MiningBuildingBuilder.DELAY * Miner.MILLISECOND);
            _timer.AutoReset = true;
            _timer.Elapsed += LastTimeMineSet;
            _timer.Elapsed += saveCharacter;
            _timer.Start();
        }

        private void LastTimeMineSet(object obj, ElapsedEventArgs e)
        {
            LastTimeMine = DateTime.Now;
        }
    }
}
