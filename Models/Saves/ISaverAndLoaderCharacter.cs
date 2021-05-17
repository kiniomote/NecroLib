using NecroLib.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Saves
{
    public interface ISaverAndLoaderCharacter
    {
        void Save(ICharacter character);
        ICharacter Load();

        bool HasSave();
    }
}
