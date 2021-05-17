using NecroLib.Models.Characters.Items;
using NecroLib.Models.Images;
using NecroLib.Models.Quests;
using NecroLib.Models.Units.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NecroLib.Models.Characters
{
    [Serializable]
    public class Character : ICharacter
    {
        public ILevel Level { get; private set; }
        public IHeroCharacteristicSet Characteristics { get; private set; }
        public IInventory Inventory { get; private set; }
        public IOwnership Ownership { get; private set; }
        public IQuestBook QuestBook { get; private set; }

        public IImagePath Image { get; set; }
        public IImagePath IconImage { get; set; }

        public Character()
        {
            Characteristics = new HeroCharacteristicSet();
            Level = new Level(Characteristics.TakePoints);
            Inventory = new Inventory();
            Ownership = new Ownership();
            QuestBook = new QuestBook();
            setDelegates();
            Image = new ImagePath(ImagePaths.CHARACTER);
            IconImage = new ImagePath(ImagePaths.CHARACTER, ImagePaths.ICON_IMAGE);
        }

        public int GetCharacteristic(HeroAttribute attribute)
        {
            bool battleAttribute = Characteristics.BattleCharacteristics.ContainsKey(attribute);
            int attributeCharacter = battleAttribute ? 
                Characteristics.BattleCharacteristics[attribute].GetValue() : 
                Characteristics.MiningCharacteristics[attribute].GetValue();
            int attributeEquipment = battleAttribute ?
                Inventory.Equipments.GetItemSetBattleCharacteristic(attribute) :
                Inventory.Equipments.GetItemSetMiningCharacteristic(attribute);

            return attributeCharacter + attributeEquipment;
        }

        private void setDelegates()
        {
            foreach (IEquipmentSlot slot in Inventory.Equipments.EquipmentSlots.Values)
            {
                slot.SetEnoughLevelEvent(Level.EnoughLevel);
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            
        }
    }
}
