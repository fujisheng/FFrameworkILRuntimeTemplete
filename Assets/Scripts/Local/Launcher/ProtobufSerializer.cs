using Framework.Service.Network;
using ProtoBuf;
using System;
using System.IO;

namespace Game
{
    public class ProtobufSerializer : INetworkSerializeHelper
    {
        public byte[] Serialize<T>(T data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<T>(ms, data);
                byte[] bytes = ms.ToArray();
                return bytes;
            }
        }

        public byte[] SerializeNonGeneric(object data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.NonGeneric.Serialize(ms, data);
                byte[] bytes = ms.ToArray();
                return bytes;
            }
        }

        public T Deserialize<T>(byte[] bytes)
        {
            using (MemoryStream ms1 = new MemoryStream(bytes))
            {
                var p1 = Serializer.Deserialize<T>(ms1);
                return p1;
            }
        }

        public object DeserializeNonGeneric(Type type, byte[] bytes)
        {
            using(MemoryStream ms = new MemoryStream(bytes))
            {
                return Serializer.NonGeneric.Deserialize(type, ms);
            }
        }
    }
}
