using Framework.Service;
using Framework.Service.FSM;
using Framework.Service.Network;
using Game;
using System;
using System.Linq;
using UnityEngine;

public class NetworkTest : State<Launcher>
{
    public string serverIp = "192.168.20.54";
    public int port = 8889;
    INetworkService network;

    uint encryptSeed;
    uint decryptSeed;

    public override void OnEnter(IFSM<Launcher> fsm)
    {
        fsm.Owner.context.Bind<INetworkChannel>().AsInstance(new TcpChannel());
        fsm.Owner.context.Bind<INetworkPackageHelper>().AsInstance(new DefaultNetworkPackageHelper(new PacketPool()));
        fsm.Owner.context.Bind<INetworkSerializeHelper>().AsInstance(new ProtobufSerializer());
        fsm.Owner.context.Bind<INetworkBCCHelper>().AsInstance(new DefaultNetworkBCCHelper());
        fsm.Owner.context.Bind<INetworkCompressHelper>().AsInstance(new DefaultNetworkCompressHelper());

        network = Services.Get<INetworkService>();

        network.OnConnectionSuccessfulHandler += OnConnected;
        network.OnConnectionFailedHandler += OnConnectionFailed;
        network.OnReceiveHandler += OnReceive;

        network.Connect(serverIp, port);
    }

    void OnConnected(IAsyncResult result)
    {
        Debug.Log("连接服务器成功");
    }

    void OnConnectionFailed(string msg)
    {
        Debug.Log($"连接服务器失败 : {msg}");
    }

    bool isFirst = false;
    void OnReceive(INetworkPacket packet)
    {
        if (encryptSeed == 0 || decryptSeed == 0)
        {
            var bytes = packet.Data;
            var encryptSeedBytes = GetRange(bytes, 0, 3).Reverse().ToArray();
            var decryptSeedBytes = GetRange(bytes, 4, 7).Reverse().ToArray();
            encryptSeed = BitConverter.ToUInt32(encryptSeedBytes, 0);
            decryptSeed = BitConverter.ToUInt32(decryptSeedBytes, 0);

            UnityEngine.Debug.Log($"收到的加密种子 encrypt:{encryptSeed}  decrypt:{decryptSeed}");
            network.SetNetworkEncryptHelper(new DefaultNetworkEncryptHelper(encryptSeed, decryptSeed));
            isFirst = true;
        }
        else
        {
            isFirst = false;
        }

        if (!isFirst && packet.Head.ID == (3<<8 | 1))
        {
            try
            {
                var s = new ProtobufSerializer();
                var r = s.Deserialize<GamerPVPPingS2C>(packet.Data);
                UnityEngine.Debug.Log($"serverTime:{r.serverTime}");
            }
            catch(Exception ex)
            {
                UnityEngine.Debug.Log($"解析数据出错:{ex}");
            }
        }
    }

    float time = 0;
    public override void OnUpdate(IFSM<Launcher> fsm)
    {
        time += Time.deltaTime;
        if(time > 2f)
        {
            ushort id = 3 << 8 | 1;

            network.Send(id, new GamerPVPPingC2S
            {
                clientTime = 101010,
            });
            time = 0;
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
