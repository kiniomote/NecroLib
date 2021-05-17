using NecroLib.Models.Characters;
using NecroLib.Services.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Saves
{
    public class SaverAndLoaderCharacter : ISaverAndLoaderCharacter
    {
        private IClassSerializer<ICharacter> _serializer;
        private IStaticDataHandler _staticDataHandler;

        public SaverAndLoaderCharacter(IClassSerializer<ICharacter> serializer, IStaticDataHandler staticDataHandler)
        {
            _serializer = serializer;
            _staticDataHandler = staticDataHandler;
            _staticDataHandler.ReadStaticData();
        }

        public ICharacter Load()
        {
            ICharacter character = HasSave() ? _serializer.Deserialize() : new Character();
            _staticDataHandler.ReadQuests(character.QuestBook);
            return character;
        }

        public void Save(ICharacter character)
        {
            _serializer.Serialize(character);
        }

        public bool HasSave()
        {
            return _serializer.ClassExsist();
        }
    }
}
