using System;
using UnityEngine;

public class GameLogic
{
    public enum GameResult { None, Win, Lose, Draw }

    public BlockController block_control;

    /// <summary> 현재 보드의 보태 정보 </summary>
    public Constants.PlayerType[,] board;

    public BasePlayerState first_player_state;
    public BasePlayerState second_player_state;
    private BasePlayerState cur_player_state;

    /// <summary> 생성자 </summary>
    /// <param name="block_control">블럭을 컨트롤하는 컨트롤러</param>
    /// <param name="game_t">현재 게임 타입</param>
    public GameLogic(BlockController block_control, Constants.GameType game_t)
    {
        this.block_control = block_control;

        this.board = new Constants.PlayerType[Constants.BlcokColumnCount, Constants.BlcokColumnCount];

        switch (game_t)
        {
            case Constants.GameType.Single:
                break;
            case Constants.GameType.Multi:
                break;
            case Constants.GameType.Dual:
                this.first_player_state = new PlayerState(true);
                this.second_player_state = new PlayerState(false);

                SetState(this.first_player_state);
                break;
        }
    }

    /// <summary> 
    /// 턴이 바뀔 때 , 기존 진행하던 상태를 Exit 하고 
    /// 이번 턴의 상태를 cur_state에 할당 후 
    /// Enter 호출 
    /// </summary>
    public void SetState(BasePlayerState state)
    {
        cur_player_state?.OnExit(this);
        cur_player_state = state;
        cur_player_state?.OnEnter(this);
    }

    // board 배열에 새로운 Marker 값 할당
    public bool SetNewBoardValue(Constants.PlayerType player_t, int row, int col)
    {
        if (board[row, col] != Constants.PlayerType.None)
        {
            return false;
        }
        else if (player_t != Constants.PlayerType.None)
        {
            board[row, col] = player_t;

            if (player_t == Constants.PlayerType.O)
            {
                block_control.PlaceMarker(Block.MarkerType.O, row, col);
            }
            else if (player_t == Constants.PlayerType.X)
            {
                block_control.PlaceMarker(Block.MarkerType.X, row, col);
            }
            return true;
        }

        return false;
    }

    public bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for (int i = 0; i < Constants.BlcokColumnCount; i++)
        {
            for (int j = 0; j < Constants.BlcokColumnCount; j++)
            {
                if (board[i, j] != Constants.PlayerType.None)
                    return false;
            }
        }
        return true;
    }

    public void EndGame(GameResult game_result)
    {
        // TODO: Game Logic 정리
        SetState(null);
        this.first_player_state = null;
        this.second_player_state = null;

        // TODO: 유저에게 Game Over 표시

        Debug.Log("GAME OVER");
    }

    public GameResult CheckGameResult()
    {
        if (CheckGameWin(Constants.PlayerType.O, this.board))
        {
            return GameResult.Win;
        }
        else if (CheckGameWin(Constants.PlayerType.X, this.board))
        {
            return GameResult.Lose;
        }
        else if (CheckGameDraw(this.board))
            return GameResult.Draw;
        else
            return GameResult.None;
    }

    private bool CheckGameWin(Constants.PlayerType player_t, Constants.PlayerType[,] board)
    {
        for (int row = 0; row < Constants.BlcokColumnCount; row++)
        {
            if (board[row, 0] == player_t && board[row, 0] == player_t && board[row, 0] == player_t)
            {
                return true;
            }
        }
        for (int col = 0; col < Constants.BlcokColumnCount; col++)
        {
            if (board[0, col] == player_t && board[1, col] == player_t && board[2, col] == player_t)
            {
                return true;
            }
        }

        if (board[0, 0] == player_t && board[1, 1] == player_t && board[2, 2] == player_t)
        {
            return true;
        }
        else if (board[2, 0] == player_t && board[1, 1] == player_t && board[0, 2] == player_t)
        {
            return true;
        }

        return false;
    }
}
