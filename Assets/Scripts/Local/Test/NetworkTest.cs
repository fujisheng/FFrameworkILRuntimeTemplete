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

    byte[] encryptSeed;
    byte[] decryptSeed;

    public override void OnEnter(IFSM<Launcher> fsm)
    {
        network = Services.Get<INetworkService>();
        network.SetPackager(new DefaultPackager(new PacketPool()));
        network.SetNetworkChannel(new TcpChannel());

        network.OnConnectionSuccessfulHandler += OnConnected;
        network.OnConnectionFailedHandler += OnConnectionFailed;
        network.OnReceiveHandler += OnReceive;

        network.Connect(serverIp, port);
    }

    void OnConnected(IAsyncResult result)
    {
        Debug.Log("连接服务器成功");
        //network.Send()
    }

    void OnConnectionFailed(string msg)
    {
        Debug.Log($"连接服务器失败 : {msg}");
    }

    void OnReceive(IPacket packet)
    {
        if(encryptSeed == null || decryptSeed == null)
        {
            var bytes = packet.Bytes;
            encryptSeed = GetRange(bytes, 0, 3).Reverse().ToArray();
            decryptSeed = GetRange(bytes, 4, 7).Reverse().ToArray();
            network.SetEncryptor(new DefaultEncryptor(encryptSeed, decryptSeed));
        }
        Debug.Log($"id:{packet.Id}");
        Debug.Log($"Length:{packet.Length}");
        UnityEngine.Debug.Log($"收到消息{bytesToString(packet.Bytes)}");
        network.Send<LoginBySessionC2S>(0, new LoginBySessionC2S
        {
            Id = 10001
        });
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

    public static string bytesToString(byte[] bytes)
    {
        var result = "";
        foreach (var b in bytes)
        {
            result += b;
        }
        return result;
    }
}
