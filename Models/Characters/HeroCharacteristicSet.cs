using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Characters
{
    [Serializable]
    public class HeroCharacteristicSet : IHeroCharacteristicSet
    {
        private const int BASE_POINTS = 3;
        private const int LEVELS_FOR_EXTRA_POINT = 2;

        public Dictionary<HeroAttribute, IHeroCharacteristic> BattleCharacteristics { get; private set; }
        public Dictionary<HeroAttribute, IHeroCharacteristic> MiningCharacteristics { get; private set; }

        private int _freeBattlePoints;
        private int _freeMiningPoints;

        public Dictionary<HeroAttribute, IImagePath> IconImages { get; }

        private LocalizedString _name = new LocalizedString(LocalizationNames.HERO_CHARACTERISTICS);

        public HeroCharacteristicSet()
        {
            BattleCharacteristics = new Dictionary<HeroAttribute, IHeroCharacteristic>();
            MiningCharacteristics = new Dictionary<HeroAttribute, IHeroCharacteristic>();
            IconImages = new Dictionary<HeroAttribute, IImagePath>();

            List<HeroAttribute> militaryHeroAttributes = new List<HeroAttribute>()
            {
                HeroAttribute.Attack,
                HeroAttribute.Armor,
                HeroAttribute.AttackSpeed,
                HeroAttribute.MovementSpeed,
            };

            List<HeroAttribute> miningHeroAttributes = new List<HeroAttribute>()
            {
                HeroAttribute.MiningStone,
                HeroAttribute.MiningMetal,
                HeroAttribute.MiningSilk,
                HeroAttribute.MiningRotRune,
            };

            foreach (HeroAttribute attribute in militaryHeroAttributes)
            {
                BattleCharacteristics.Add(attribute, new HeroCharacteristic(LocalizationNames.BATTLE_CHARACTERISTICS[attribute], spendBattlePoints));
                IconImages.Add(attribute, new ImagePath(ImagePaths.BATTLE_CHARACTERISTICS[attribute], ImagePaths.ICON_IMAGE));
            }

            foreach (HeroAttribute attribute in miningHeroAttributes)
            {
                MiningCharacteristics.Add(attribute, new HeroCharacteristic(LocalizationNames.MINING_CHARACTERISTICS[attribute], spendMiningPoints));
                IconImages.Add(attribute, new ImagePath(ImagePaths.MINING_CHARACTERISTICS[attribute], ImagePaths.ICON_IMAGE));
            }
        }

        public void TakePoints(int level)
        {
            if (level == 0)
                return;
            int points = BASE_POINTS + (level / LEVELS_FOR_EXTRA_POINT);
            _freeBattlePoints += points;
            _freeMiningPoints += points;
        }

        private bool spendBattlePoints(int points = 1)
        {
            bool enough_points = _freeBattlePoints >= points;
            _freeBattlePoints -= enough_points ? points : 0;
            return enough_points;
        }

        private bool spendMiningPoints(int points = 1)
        {
            bool enough_points = _freeMiningPoints >= points;
            _freeMiningPoints -= enough_points ? points : 0;
            return enough_points;
        }

        // Getters

        public int GetFreeBattlePoints()
        {
            return _freeBattlePoints;
        }

        public int GetFreeMiningPoints()
        {
            return _freeMiningPoints;
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
