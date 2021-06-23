using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class NetworkServer : MonoBehaviour
{
    // Start is called before the first frame update
    Socket serverSocket;
    MemoryStream stream = new MemoryStream();

    void Start()
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(new IPEndPoint(ip, 10001));
        serverSocket.Listen(10);
        Debug.Log($"启动监听{serverSocket.LocalEndPoint.ToString()}成功");
        Thread myThread = new Thread(ListenClientConnect);
        myThread.Start();
    }

    void ListenClientConnect()
    {
        serverSocket.BeginAccept(OnAccept, serverSocket);
        //serverSocket.BeginReceive(stream.GetBuffer(), (int)stream.Position, (int)(stream.Length - stream.Position), SocketFlags.None, OnRead, serverSocket);
    }

    void OnAccept(IAsyncResult result)
    {
        UnityEngine.Debug.Log($"有客服端连接到服务器:{result.AsyncState.ToString()}");
        var msg = Encoding.UTF8.GetBytes("12344321");
        UnityEngine.Debug.Log($"发送了一条消息{bytesToString(msg)}");
        serverSocket.BeginSend(msg, 0, msg.Length, SocketFlags.None, null, null);
        
    }

    public static string bytesToString(byte[] bytes)
    {
        var result = "";
        foreach(var b in bytes)
        {
            result += b;
        }
        return result;
    }

    void OnRead(IAsyncResult result)
    {
        //int bytesRead = 0;
        //try
        //{
        //    lock (stream)
        //    {
        //        bytesRead = stream.EndRead(result);
        //    }
        //    if (bytesRead <= 0)
        //    {
        //        UnityEngine.Debug.LogWarning("Connection was closed by the server: bytesRead < 1");
        //        return;
        //    }

        //    var byteBuffer = new byte[1024];

        //    lock (stream)
        //    {
        //        Array.Clear(byteBuffer, 0, byteBuffer.Length);
        //        stream.BeginRead(byteBuffer, 0, 1024, OnRead, null);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    UnityEngine.Debug.LogErrorFormat("接收消息失败:{0}", ex.ToString());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        serverSocket.Close();
        stream.Close();
    }
}
