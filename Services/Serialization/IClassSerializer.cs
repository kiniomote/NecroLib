using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Services.Serialization
{
    public interface IClassSerializer<T> where T : class
    {
        void Serialize(T obj);

        T Deserialize();

        bool ClassExsist();
    }
}
