using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroLib.Services.Serialization;
using NecroLib.Models.Localization;
using NecroLib.Models.Dialogs;
using NecroLib.Models.Quests;

namespace NecroLib.Models.Saves
{
    public class StaticDataHandler : IStaticDataHandler
    {
        private Dictionary _dictionary;
        private LanguageChanger _languageChanger;
        private BinarySerializer _binarySerializer;
        private ICommunication _communication;

        public StaticDataHandler(string path)
        {
            _dictionary = new Dictionary();
            _languageChanger = new LanguageChanger();
            _communication = new Communication();
            _binarySerializer = new BinarySerializer(path);
        }

        public void ReadStaticData()
        {
            _binarySerializer.Deserialize(_languageChanger, LanguageChanger.FILE_NAME);
            _binarySerializer.Deserialize(_dictionary, Dictionary.FILE_NAME);
            _binarySerializer.Deserialize(_communication, Communication.FILE_NAME);
        }

        public void ReadQuests(IQuestBook questBook)
        {
            _binarySerializer.Deserialize(questBook, QuestBook.FILE_NAME);
        }
    }
}
