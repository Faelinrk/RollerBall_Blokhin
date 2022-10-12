using System;
using System.IO;
using System.Xml.Serialization;

namespace RollerBall.Data
{
    public class XMLData<T> : IData<T>
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(T));
        public void Save(T data, string path)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            using(var fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }
        public T Load(string path)
        {
            T result;
            if (!File.Exists(path)) return default (T);
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)serializer.Deserialize(fs);
            }
            return result;
        }
    }

}
