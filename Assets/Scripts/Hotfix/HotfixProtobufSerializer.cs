using ProtoBuf;
using System.IO;
using UnityEngine;

namespace Game.Hotfix
{
    public class HotfixProtobufSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">数据实例</param>
        /// <returns>bytes</returns>
        public byte[] Serialize<T>(T data) where T : class
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    var type = typeof(T);
                    PType.RegisterType(type.FullName, type);
                    Serializer.Serialize(stream, data);
                    return stream.ToArray();
                }
            }
            catch (IOException ex)
            {
                Debug.Log($"[ProtobufSerializer] 错误：{ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="bytes">数据</param>
        /// <returns>数据实例</returns>
        public T Deserialize<T>(byte[] bytes) where T : class
        {
            try
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var type = typeof(T);
                    PType.RegisterType(type.FullName, type);
                    return Serializer.Deserialize(type, new MemoryStream(bytes)) as T;
                }
            }
            catch (IOException ex)
            {
                Debug.Log($"[ProtobufSerializer] 错误：{ex.Message}");
                return null;
            }
        }
    }
}