using UnityEngine;

public class AIState : BasePlayerState
{
    public override void OnEnter(GameLogic game_logic)
    {
        Constants.PlayerType[,] board = game_logic.GetBoard();

        var result = TicTacToeAI.GetBestMove(board);
        if (result.HasValue)
        {
            HandleMove(game_logic, result.Value.row, result.Value.col);
        }
        else
        {
            game_logic.EndGame(GameLogic.GameResult.Draw);
        }
    }

    public override void OnExit(GameLogic game_logic)
    {

    }

    public override void HandleMove(GameLogic game_logic, int row, int col)
    {
        ProcessMove(game_logic, Constants.PlayerType.X, row, col);
    }


    protected override void HandleNextTurn(GameLogic game_logic)
    {
        game_logic.SetState(game_logic.first_player_state);
    }
}


