using Framework;
using Framework.Service.FSM;
using Framework.Service.Network;
using System;
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
            if (encryptSeed == 0 || decryptSeed == 0)
            {
                var bytes = packet.Data;
                if(bytes.Length != 8)
                {
                    return;
                }

                encryptSeed = Utility.Converter.GetUInt32(bytes, 0, true);
                decryptSeed = Utility.Converter.GetUInt32(bytes, 4, true);
                Debug.Log($"收到的加密种子 encrypt:{encryptSeed}  decrypt:{decryptSeed}");
                Modules.Network.SetNetworkEncryptHelper(new DefaultNetworkEncryptHelper(encryptSeed, decryptSeed));
            }
            else
            {
                Modules.Script.InvokeMethod("Game.Hotfix.HotfixNetwork", "OnReceive", null, new object[] { packet });
            }
        }
    }
}