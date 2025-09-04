using System;


public static class TicTacToeAI
{
    public static (int row, int col)? GetBestMove(Constants.PlayerType[,] board)
    {
        // 턴 표시
        GameManager.Instance.SetGameTurnPanel(GameUIController.GameTurnPanelType.XTurn);

        // AI 처리
        float best_score = -1000;
        (int row, int col) move_pos = (-1, -1);

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None)
                {
                    board[row, col] = Constants.PlayerType.X;
                    float score = TicTacToeAI.DoMinMax(board, 0, false);
                    board[row, col] = Constants.PlayerType.None;
                    if (score > best_score)
                    {
                        best_score = score;
                        move_pos = (row, col);
                    }
                }
            }
        }

        if (move_pos != (-1, -1))
        {
            return (move_pos.row, move_pos.col);
        }
        return null;
    }

    private static float DoMinMax(Constants.PlayerType[,] board , int depth,bool isMaximizing)
    {
        if (CheckGameWin(Constants.PlayerType.O, board))
        {
            return -10 + depth;
        }
        else if (CheckGameWin(Constants.PlayerType.X, board))
        {
            return 10 - depth;
        }
        else if (CheckGameDraw(board))
        {
            return 0;
        }
        else if (isMaximizing)
        {
            float best_score = float.MinValue;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.X;

                        float score = DoMinMax(board, depth + 1, false);
                        board[row, col] = Constants.PlayerType.None;

                        best_score = MathF.Max(score, best_score);
                    }
                }
            }
            return best_score;
        }
        else
        {
            float best_score = float.MaxValue;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.O;

                        float score = DoMinMax(board, depth + 1, true);
                        board[row, col] = Constants.PlayerType.None;

                        best_score = MathF.Min(score, best_score);
                    }
                }
            }
            return best_score;
        }
    }

    public static bool CheckGameDraw(Constants.PlayerType[,] board)
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

    public static bool CheckGameWin(Constants.PlayerType player_t, Constants.PlayerType[,] board)
    {
        for (int row = 0; row < Constants.BlcokColumnCount; row++)
        {
            if (board[row, 0] == player_t && board[row, 1] == player_t && board[row, 2] == player_t)
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