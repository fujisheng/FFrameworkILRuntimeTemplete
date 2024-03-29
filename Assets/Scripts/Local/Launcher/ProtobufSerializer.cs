﻿using ProtoBuf;
using System.IO;
using UnityEngine;
using Framework.Service.Network;

namespace Game
{
    public class ProtobufSerializer : INetworkSerializeHelper
    {
        public byte[] Serialize<T>(T data) where T : class
        {
            try
            {
                using (var stream = new MemoryStream())
                {
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

        public T Deserialize<T>(byte[] bytes) where T : class
        {
            try
            {
                using(var stream = new MemoryStream(bytes))
                {
                    return Serializer.Deserialize(typeof(T), stream) as T;
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