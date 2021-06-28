using Framework.Service;
using Framework.Service.Loop;
using Framework.Service.Network;
using System;
using System.IO;
using UnityEngine;

namespace Game.Hotfix
{
    public static class HotfixNetwork
    {
        static ProtobufSerializer serializer = new ProtobufSerializer();

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
            if(packet.ID != GetMsgId(CMD.PVP, ACT.PVP_PING))
            {
                return;
            }

            UnityEngine.Debug.Log(packet.Head);
            try
            {
                var p1 = serializer.DeserializeNonGeneric(typeof(GamerPVPPingS2C), packet.Data);
                var r = p1 as GamerPVPPingS2C;
                UnityEngine.Debug.Log($"serverTime:{r.serverTime}");
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log($"解析数据出错:{ex}");
            }
        }

        static float time = 0;
        static void OnUpdate()
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                ushort id = GetMsgId(CMD.PVP, ACT.PVP_PING);
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = new GamerPVPPingC2S
                    {
                        clientTime = 101010,
                    };
                    var bytes = serializer.SerializeNonGeneric(data);
                    Modules.Network.Send(id, bytes);
                }
                time = 0;
            }
        }
    }
}
