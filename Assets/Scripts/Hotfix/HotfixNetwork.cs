using Framework.Service;
using Framework.Service.Loop;
using Framework.Service.Network;
using ProtoBuf;
using System;
using System.IO;
using UnityEngine;

namespace Game.Hotfix
{
    public static class HotfixNetwork
    {
        static HotfixProtobufSerializer serializer = new HotfixProtobufSerializer();

        public static void Init()
        {
            Services.Get<ILoopService>().AddUpdate(OnUpdate);

        }

        static ushort GetMsgId(CMD cmd, ACT act)
        {
            return (ushort)((int)cmd << 8 | (int)act);
        }

        public static void OnReceive(INetworkPacket packet)
        {
            if (packet.ID != GetMsgId(CMD.PVP, ACT.PVP_PING))
            {
                return;
            }

            try
            {
                var result = serializer.Deserialize<GamerPVPPingS2C>(packet.Data);
                Debug.Log($"serverTime:{result.serverTime}");
            }
            catch (Exception ex)
            {
                Debug.Log($"解析数据出错:{ex}");
            }
        }

        static float time = 0;
        static void OnUpdate()
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                try
                {
                    ushort id = GetMsgId(CMD.PVP, ACT.PVP_PING);
                    var data = new GamerPVPPingC2S
                    {
                        clientTime = 101010,
                    };
                    var bytes = serializer.Serialize(data);
                    Modules.Network.Send(id, bytes);
                }
                catch (Exception ex)
                {
                    Debug.Log($"发送数据错误:{ex}");
                }
                time = 0;
            }
        }
    }
}
