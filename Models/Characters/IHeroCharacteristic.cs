using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters
{
    public enum HeroAttribute
    {
        Attack=0,
        Armor=1,
        AttackSpeed=2,
        MovementSpeed=3,

        MiningRotRune=4,
        MiningStone=5,
        MiningMetal=6,
        MiningSilk=7
    }

    public interface IHeroCharacteristic : INameable, IDescribeable
    {
        void Upgrade(int up_value = 1);

        int GetValue();
    }
}
