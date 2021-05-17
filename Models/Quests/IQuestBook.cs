using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Quests
{
    public interface IQuestBook : Services.Serialization.ISerializable
    {
        List<IQuest> Quests { get; }
        void LoadQuests(List<IQuest> quests);
    }
}
