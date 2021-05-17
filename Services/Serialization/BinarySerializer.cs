using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NecroLib.Services.Serialization
{
    public class BinarySerializer: ISerializer
    {
        private string _path;

        public BinarySerializer(string path)
        {
            _path = path;
        }

        public void Serialize(ISerializable item, string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.Create(Path.Combine(_path, filename)))
            {
                object to_serialize = item.Serialize();
                bf.Serialize(stream, to_serialize);
            }
        }

        public void Deserialize(ISerializable item, string filename)
        {
            if (!File.Exists(Path.Combine(_path, filename)))
                return;

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.Open(Path.Combine(_path, filename), FileMode.Open))
            {
                object to_deserialize = bf.Deserialize(stream);
                item.Deserialize(to_deserialize);
            }
            
        }
    }
}
