using System;
using System.Collections.Generic;

namespace NecroLib.Services.Serialization
{
    public interface ISerializer
    {
        void Serialize(ISerializable item, string file_name);

        void Deserialize(ISerializable item, string file_name);
    }
}
