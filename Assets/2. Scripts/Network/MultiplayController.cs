using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using SocketIOClient;
using UnityEditor.Compilation;
using UnityEngine;

/// <summary> joinRoom / crateRoom 이벤트 전달 시 전달되는 데이터 타입 </summary>
public class RoomData
{
    [JsonProperty("rooId")]
    public string roomId { get; set; }
}

/// <summary> 상대방이 둔 마커 위치 </summary>
public class BlockData
{
    [JsonProperty("blockIndex")]
    public int blockIndex { get; set; }
}

public class MultiplayController
{
    private SocketIOUnity socket;

    public MultiplayController()
    {
        var uri = new Uri(Constants.SocketServerURL);

        socket = new SocketIOUnity(uri, new SocketIOOptions
        {
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });

        socket.On("createRoom", CreateRoom);
        socket.On("joinRoom", JoinRoom);
        socket.On("startGame", StartGame);
        socket.On("exitGame", ExitGame);
        socket.On("endGame", EndGame);
        socket.On("doOpponent", DoOpponent);
    }

    private void CreateRoom(SocketIOResponse response)
    {
        var data = response.GetValue<RoomData>();
    }

    private void JoinRoom(SocketIOResponse response)
    {
        var data = response.GetValue<RoomData>();
    }

    private void StartGame(SocketIOResponse response)
    {
        var data = response.GetValue<RoomData>();
    }

    private void ExitGame(SocketIOResponse response)
    {

    }

    private void EndGame(SocketIOResponse response)
    {

    }

    private void DoOpponent(SocketIOResponse response)
    {
        var data = response.GetValue<BlockData>();
    }
}
