using Framework.Service.FSM;
using Framework.Service.Network;
using System;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class ConnectServer : State<Launcher>
    {
        public string serverIp = "192.168.1.158";
        public int port = 8889;

        uint encryptSeed;
        uint decryptSeed;

        public override void OnEnter(IFSM<Launcher> fsm)
        {
            Modules.Script.InvokeMethod("Game.Hotfix.HotfixNetwork", "Init");
            Modules.Network.OnConnectionSuccessfulHandler += OnConnected;
            Modules.Network.OnConnectionFailedHandler += OnConnectionFailed;
            Modules.Network.OnReceiveHandler += OnReceive;

            Modules.Network.Connect(serverIp, port);
        }

        void OnConnected(IAsyncResult result)
        {
            Debug.Log("连接服务器成功");
        }

        void OnConnectionFailed(string msg)
        {
            Debug.Log($"连接服务器失败 : {msg}");
        }

        void OnReceive(INetworkPacket packet)
        {
            UnityEngine.Debug.Log("收到一个消息包");
            if (encryptSeed == 0 || decryptSeed == 0)
            {
                var bytes = packet.Data;
                var encryptSeedBytes = GetRange(bytes, 0, 3).Reverse().ToArray();
                var decryptSeedBytes = GetRange(bytes, 4, 7).Reverse().ToArray();
                encryptSeed = BitConverter.ToUInt32(encryptSeedBytes, 0);
                decryptSeed = BitConverter.ToUInt32(decryptSeedBytes, 0);

                Debug.Log($"收到的加密种子 encrypt:{encryptSeed}  decrypt:{decryptSeed}");
                Modules.Network.SetNetworkEncryptHelper(new DefaultNetworkEncryptHelper(encryptSeed, decryptSeed));
            }
            else
            {
                Modules.Script.InvokeMethod("Game.Hotfix.HotfixNetwork", "OnReceive", null, new object[] { packet });
            }
        }

        byte[] GetRange(byte[] bytes, int startIndex, int endIndex)
        {
            var result = new byte[endIndex - startIndex + 1];
            int j = 0;
            for (int i = startIndex; i <= endIndex; i++, j++)
            {
                result[j] = bytes[i];
            }
            return result;
        }
    }
}