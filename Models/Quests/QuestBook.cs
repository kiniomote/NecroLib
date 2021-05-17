using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using NecroLib.Services.Serialization;
using NecroLib.Models.Saves;

namespace NecroLib.Models.Quests
{
    [Serializable]
    public class QuestBook : IQuestBook
    {
        public const string FILE_NAME = "quests.dat";

        [field: NonSerialized]
        public List<IQuest> Quests { get; private set; }

        private List<string> _completedQuests = new List<string>();

        public QuestBook()
        {
            Quests = new List<IQuest>();
            _completedQuests = new List<string>();
        }

        public void LoadQuests(List<IQuest> quests)
        {
            Quests = quests ?? new List<IQuest>();

            _completedQuests.ForEach(completedQuest => Quests.Find(quest => quest.ToString() == completedQuest)?.Complete(null));
        }

        public object Serialize()
        {
            return Quests;
        }

        public void Deserialize(object toDeserialize)
        {
            if (toDeserialize == null)
                Quests = new List<IQuest>();
            else
                LoadQuests((List<IQuest>)toDeserialize);
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            _completedQuests = new List<string>();
            foreach (IQuest quest in Quests)
            {
                if (quest.Completed())
                {
                    _completedQuests.Add(quest.ToString());
                }
            }
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            Quests = new List<IQuest>();
        }
    }
}
