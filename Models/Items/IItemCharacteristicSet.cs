using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Characters;

namespace NecroLib.Models.Items
{
    public interface IItemCharacteristicSet
    {
        Dictionary<HeroAttribute, IItemCharacteristic> BattleCharacteristics { get; }
        Dictionary<HeroAttribute, IItemCharacteristic> MiningCharacteristics { get; }
    }
}
