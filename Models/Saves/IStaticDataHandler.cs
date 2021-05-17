using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Quests;

namespace NecroLib.Models.Saves
{
    public interface IStaticDataHandler
    {
        void ReadQuests(IQuestBook questBook);
        void ReadStaticData();
    }
}
