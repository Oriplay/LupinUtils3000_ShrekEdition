using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

namespace LupinUtils.Serializable
{
    public class SerializeUtils 
    {
        /// <summary>
        /// Clone serialize object
        /// BinaryFormatter and MemoryStreeam
        /// </summary>
        /// <param name="source">Serializable object</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Clone</returns>
        public static T SerializeClone<T>([NotNull]T source)
        {
            if (!typeof(T).IsSerializable)
            {
                return default(T);
            }
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream,source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}
