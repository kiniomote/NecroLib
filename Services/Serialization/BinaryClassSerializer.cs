using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NecroLib.Services.Serialization
{
    public class BinaryClassSerializer<T> : IClassSerializer<T>
        where T : class
    {
        private string _path;
        private string _filename;

        public BinaryClassSerializer(string path, string filename)
        {
            _path = path;
            _filename = filename;
        }

        public T Deserialize()
        {
            T obj = null;
            if (!ClassExsist())
                throw new Exception("File don't exsist");

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.Open(Path.Combine(_path, _filename), FileMode.Open))
            {
                obj = (T)bf.Deserialize(stream);
            }
            return obj;
        }

        public void Serialize(T obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.Create(Path.Combine(_path, _filename)))
            {
                bf.Serialize(stream, obj);
            }
        }

        public bool ClassExsist()
        {
            return File.Exists(Path.Combine(_path, _filename));
        }
    }
}
