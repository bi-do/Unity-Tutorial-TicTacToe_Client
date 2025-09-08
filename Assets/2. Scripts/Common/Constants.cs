public static class Constants
{
    public const string ServerURL = "http://localhost:3000";
    public const string SocketServerURL = "ws://localhost:3000";

    public enum MultiplayControllerState
    {
        CreateRoom, // 방 생성
        JoinRoom,   // 생성된 방에 참여
        StartGame,  // 생성된 방에 다른 유저가 참여해서 게임을 시작
        ExitGame,   // 클라이언트가 방으 빠져 나왔을 때
        EndGame     // 상대방이 접속을 끊거나 방을 나갔을 때
    }

    public enum GameType { Single, Dual, Multi }
    public enum PlayerType{ None , O , X}

    public const int BlcokColumnCount = 3;
}