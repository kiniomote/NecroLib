using System;
using System.Collections.Generic;

namespace NecroLib.Services.Serialization
{
    public interface ISerializable
    {
        object Serialize();

        void Deserialize(object to_deserialize);
    }
}
