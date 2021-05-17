using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Characters
{
    public interface IHeroCharacteristicSet : INameable, IDictIconable<HeroAttribute>
    {
        Dictionary<HeroAttribute, IHeroCharacteristic> BattleCharacteristics { get; }
        Dictionary<HeroAttribute, IHeroCharacteristic> MiningCharacteristics { get; }

        void TakePoints(int level);

        int GetFreeBattlePoints();
        int GetFreeMiningPoints();
    }
}
