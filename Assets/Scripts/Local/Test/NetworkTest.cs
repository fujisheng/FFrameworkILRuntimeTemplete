using Framework.Service;
using Framework.Service.FSM;
using Framework.Service.Network;
using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTest : State<Launcher>
{
    public string serverIp = "192.168.20.54";
    public int port = 8889;
    INetworkService network;

    public override void OnEnter(IFSM<Launcher> fsm)
    {
        network = Services.Get<INetworkService>();
        var tcpConnector = new TcpChannel();
        tcpConnector.OnConnented += OnConnected;
        tcpConnector.OnConnectionFailed += OnConnectionFailed;
        network.SetPacker(new Packer());
        network.SetNetworkChannel(new TcpChannel());
       
        network.Connect(serverIp, port);
    }

    void OnConnected(IAsyncResult result)
    {
        Debug.Log("连接服务器成功");
        //network.Send()
    }

    void OnConnectionFailed()
    {
        Debug.Log("连接服务器失败");
    }
}
