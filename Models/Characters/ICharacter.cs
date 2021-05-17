using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Characters.Items;
using NecroLib.Models.Images;
using NecroLib.Models.Quests;

namespace NecroLib.Models.Characters
{
    public interface ICharacter : IImageable, IIconable
    {
        ILevel Level { get; }
        IHeroCharacteristicSet Characteristics { get; }
        IInventory Inventory { get; }
        IOwnership Ownership { get; }
        IQuestBook QuestBook { get; }

        int GetCharacteristic(HeroAttribute attribute);
    }
}
