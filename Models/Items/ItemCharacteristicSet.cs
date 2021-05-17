using NecroLib.Models.Characters;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items
{
    public class ItemCharacteristicSet : IItemCharacteristicSet
    {
        public Dictionary<HeroAttribute, IItemCharacteristic> BattleCharacteristics { get; private set; }
        public Dictionary<HeroAttribute, IItemCharacteristic> MiningCharacteristics { get; private set; }

        public ItemCharacteristicSet(int attack, int armor, int attackSpeed, int movementSpeed, int miningStone, int miningMetal, int miningRotRune, int miningSilk)
        {
            BattleCharacteristics = new Dictionary<HeroAttribute, IItemCharacteristic>()
            {
                [HeroAttribute.Attack] = new ItemCharacteristic(attack, LocalizationNames.BATTLE_CHARACTERISTICS[HeroAttribute.Attack]),
                [HeroAttribute.Armor] = new ItemCharacteristic(armor, LocalizationNames.BATTLE_CHARACTERISTICS[HeroAttribute.Armor]),
                [HeroAttribute.AttackSpeed] = new ItemCharacteristic(attackSpeed, LocalizationNames.BATTLE_CHARACTERISTICS[HeroAttribute.AttackSpeed]),
                [HeroAttribute.MovementSpeed] = new ItemCharacteristic(movementSpeed, LocalizationNames.BATTLE_CHARACTERISTICS[HeroAttribute.MovementSpeed]),
            };

            MiningCharacteristics = new Dictionary<HeroAttribute, IItemCharacteristic>()
            {
                [HeroAttribute.MiningStone] = new ItemCharacteristic(miningStone, LocalizationNames.MINING_CHARACTERISTICS[HeroAttribute.MiningStone]),
                [HeroAttribute.MiningMetal] = new ItemCharacteristic(miningMetal, LocalizationNames.MINING_CHARACTERISTICS[HeroAttribute.MiningMetal]),
                [HeroAttribute.MiningSilk] = new ItemCharacteristic(miningSilk, LocalizationNames.MINING_CHARACTERISTICS[HeroAttribute.MiningSilk]),
                [HeroAttribute.MiningRotRune] = new ItemCharacteristic(miningRotRune, LocalizationNames.MINING_CHARACTERISTICS[HeroAttribute.MiningRotRune]),
            };
        }

        public ItemCharacteristicSet(Dictionary<HeroAttribute, int> battleCharacteristics, Dictionary<HeroAttribute, int> miningCharacteristics)
        {
            BattleCharacteristics = new Dictionary<HeroAttribute, IItemCharacteristic>();
            foreach (KeyValuePair<HeroAttribute, int> attribute in battleCharacteristics)
            {
                BattleCharacteristics.Add(attribute.Key, new ItemCharacteristic(attribute.Value, LocalizationNames.BATTLE_CHARACTERISTICS[attribute.Key]));
            }

            MiningCharacteristics = new Dictionary<HeroAttribute, IItemCharacteristic>();
            foreach (KeyValuePair<HeroAttribute, int> attribute in miningCharacteristics)
            {
                MiningCharacteristics.Add(attribute.Key, new ItemCharacteristic(attribute.Value, LocalizationNames.MINING_CHARACTERISTICS[attribute.Key]));
            }
        }
    }
}
